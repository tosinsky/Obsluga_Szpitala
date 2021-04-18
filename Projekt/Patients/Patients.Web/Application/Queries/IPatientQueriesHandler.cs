namespace Patients.Web.Application
{
    using Patients.Domain.PatientAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPatientQueriesHandler
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        IEnumerable<PatientDto> GetByAppointmentDate(DateTime appointmentDate);
    }
}
