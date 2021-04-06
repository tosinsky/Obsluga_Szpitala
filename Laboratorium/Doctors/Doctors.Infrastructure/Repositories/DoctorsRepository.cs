namespace Doctors.Infrastructure
{
    using Dapper;
    using Doctors.Domain;
    using Doctors.Domain.DoctorAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DoctorsRepository : IDoctorsRepository
    {

        public DoctorsRepository()
        {
        }

        public async Task AddDoctorAsync(Doctor Doctor)
        {
            const string getAddedRowIdQueryQuery = @"SELECT CAST(SCOPE_IDENTITY() as int)";

            //utworzenie połączenia do bazy danych, klauzula using wykorzystywana jest żebyśmy nie musieli przejmować się zamykaniem polączenia
            using (var dbConnection =  new SqlConnection(Constants.connectionString)) 
            {
                //otwarcie połączenia 
                dbConnection.Open();

                //utworzenie transakcji - będziemy wstawiać dane do trzech różnych tabel
                using (DbTransaction transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        const string insertDoctorQuery = @"INSERT INTO Doctor (Number) VALUES (@number);";
                        //wykonanie zapytania sql, korzystamy tutaj z Dappera - pakietu ułatwiającego korzystanie z baz danych
                        int DoctorId = await dbConnection.QueryFirstAsync<int>(insertDoctorQuery + ";" + getAddedRowIdQueryQuery, new { number = Doctor.Number }, transaction);

                        var certificationsIds = new List<int>();

                        const string insertCertificationQuery = @"INSERT INTO Certification (Type, GrantedAt) VALUES (@type,@grantedAt);";
                        foreach (var certifition in Doctor.Certifications)
                            certificationsIds.Add(await dbConnection.QueryFirstAsync<int>(insertCertificationQuery + ";" + getAddedRowIdQueryQuery, new { type = certifition.Type, grantedAt = certifition.GrantedAt }, transaction));

                        const string insertExamitionRoomCertificationQuery = @"INSERT INTO DoctorCertification (DoctorId, CertificationId) VALUES (@DoctorId,@certificationId);";
                        foreach (var certifitionId in certificationsIds)
                            await dbConnection.QueryAsync(insertExamitionRoomCertificationQuery, new { DoctorId = DoctorId, certificationId = certifitionId }, transaction);
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


        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            using (var dbConnection = new SqlConnection(Constants.connectionString))
            {

                //otwarcie połączenia tym razem nie jest konieczne, Dapper zrobi to automatycznie w razie potrzeby
                //poprzednim razem otwarcia połączenia wymagało utworzenie transakcji
                const string selectDoctorCertificationQuery = @"SELECT * FROM DoctorCertification";

                var DoctorsCertificates =  (await dbConnection.QueryAsync(selectDoctorCertificationQuery)).Select(x=> new { CertificationId = x.CertificationId, DoctorId = x.DoctorId });

                const string selectDoctorQuery = @"SELECT * FROM Doctor";

                var Doctors = await dbConnection.QueryAsync<Doctor>(selectDoctorQuery);

                const string selectCertificationsQuery = @"SELECT * FROM Certification";

                var certifications = await dbConnection.QueryAsync<Certification>(selectCertificationsQuery);

                foreach (var Doctor in Doctors)
                {
                    var certificationsIdForGivenRoom = DoctorsCertificates.Where(x => x.DoctorId == Doctor.Id).Select(x=>x.CertificationId);
                    var certificationsForGivenRoom = certifications.Where(x => certificationsIdForGivenRoom.Contains(x.Id));
                    Doctor.AddCertifications(certificationsForGivenRoom);
                }

                return Doctors;
            }
        }

        public IEnumerable<Doctor> GetByCertificationType(int certificationType)
        {
            throw new NotImplementedException();
        }
    }
}
