namespace Patients.Infrastructure
{
    using Dapper;
    using Patients.Domain;
    using Patients.Domain.PatientAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PatientsRepository : IPatientsRepository
    {

        public PatientsRepository()
        {
        }

        public async Task AddPatientAsync(Patient Patient)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";

            //utworzenie połączenia do bazy danych, klauzula using wykorzystywana jest żebyśmy nie musieli przejmować się zamykaniem polączenia
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {
                //otwarcie połączenia 
                dbConnection.Open();

                //utworzenie transakcji - będziemy wstawiać dane do trzech różnych tabel
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string insertPatientQuery = @"INSERT INTO Patient (Name, Surname, PESEL, PhoneNumber, Birthdate) VALUES (@name, @surname, @pesel, @phonenumber, @birthdate);";
                        //wykonanie zapytania sql, korzystamy tutaj z Dappera - pakietu ułatwiającego korzystanie z baz danych
                        int PatientId = await dbConnection.QueryFirstAsync<int>(insertPatientQuery + ";" + getAddedRowIdQueryQuery, new { number = Patient.Name, surname = Patient.Surname, pesel = Patient.PESEL, phonenumber = Patient.PhoneNumber, birthdate = Patient.Birthdate }, transaction);

                        var appointmentsIds = new List<int>();

                        const string insertAppointmentQuery = @"INSERT INTO Appointment (AppointmentDate, Reason) VALUES (@appointmentDate, @reason);";
                        foreach (var appointment in Patient.Appointments)
                            appointmentsIds.Add(await dbConnection.QueryFirstAsync<int>(insertAppointmentQuery + ";" + getAddedRowIdQueryQuery, new { reason = appointment.Reason, appointmentDate = appointment.AppointmentDate }, transaction));

                        const string insertExamitionRoomAppointmentQuery = @"INSERT INTO PatientAppointment (PatientId, AppointmentId) VALUES (@PatientId,@appointmentId);";
                        foreach (var appointmentId in appointmentsIds)
                            await dbConnection.QueryAsync(insertExamitionRoomAppointmentQuery, new { PatientId = PatientId, appointmentId = appointmentId }, transaction);
                        //commit transakcji
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                //otwarcie połączenia tym razem nie jest konieczne, Dapper zrobi to automatycznie w razie potrzeby
                //poprzednim razem otwarcia połączenia wymagało utworzenie transakcji
                const string selectPatientAppointmentQuery = @"SELECT * FROM PatientAppointment";

                var PatientsAppointments = (await dbConnection.QueryAsync(selectPatientAppointmentQuery)).Select(x => new { AppointmentId = x.AppointmentId, PatientId = x.PatientId });

                const string selectPatientQuery = @"SELECT * FROM Patient";

                var Patients = await dbConnection.QueryAsync<Patient>(selectPatientQuery);

                const string selectAppointmentsQuery = @"SELECT * FROM Appointment";

                var appointments = await dbConnection.QueryAsync<Appointment>(selectAppointmentsQuery);

                foreach (var Patient in Patients)
                {
                    var appointmentsIdForGivenPatient = PatientsAppointments.Where(x => x.PatientId == Patient.Id).Select(x => x.AppointmentId);
                    var appointmentsForGivenPatient = appointments.Where(x => appointmentsIdForGivenPatient.Contains(x.Id));
                    Patient.AddAppointments(appointmentsForGivenPatient);
                }

                return Patients;
            }
        }

        public IEnumerable<Patient> GetByAppointmentDate(DateTime appointmentDate)
        {
            IPatientsRepository patientRepository = new PatientsRepository() as IPatientsRepository;
            Debug.Assert(condition: patientRepository != null);
            Task<IEnumerable<Patient>> getPatientsTask = patientRepository.GetAllAsync();
            IEnumerable<Patient> patients = getPatientsTask.Result;
            List<Patient> filteredPatients = new List<Patient>();
            foreach (Patient patient in patients)
            {
                foreach (Appointment appointment in patient.Appointments)
                {
                    if (appointment.AppointmentDate.Equals(appointmentDate))
                    {
                        filteredPatients.Add(patient);
                    }
                }
            }
            return filteredPatients;

        }

        public IEnumerable<Patient> GetBySurname(String surname)
        {
            IPatientsRepository patientRepository = new PatientsRepository() as IPatientsRepository;
            Debug.Assert(condition: patientRepository != null);
            Task<IEnumerable<Patient>> getPatientsTask = patientRepository.GetAllAsync();
            IEnumerable<Patient> patients = getPatientsTask.Result;
            List<Patient> filteredPatients = new List<Patient>();
            foreach (Patient patient in patients)
            {
                if (patient.Surname.Equals(surname))
                {
                    filteredPatients.Add(patient);
                }
            }
            return filteredPatients;
        }
    }
}
