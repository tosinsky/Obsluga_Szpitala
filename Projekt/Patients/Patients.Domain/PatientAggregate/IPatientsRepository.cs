namespace Patients.Domain.PatientAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IPatientsRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        IEnumerable<Patient> GetByAppointmentDate(DateTime appointmentDate);
        Task AddPatientAsync(Patient Patient);
        IEnumerable<Patient> GetBySurname(String surname);
    }
}
