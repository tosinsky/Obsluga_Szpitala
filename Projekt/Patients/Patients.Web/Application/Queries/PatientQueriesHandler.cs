namespace Patients.Web.Application
{
    using Patients.Domain.PatientAggregate;
    using Patients.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientQueriesHandler : IPatientQueriesHandler
    {
        private readonly IPatientsRepository PatientsRepository;

        public PatientQueriesHandler(IPatientsRepository PatientsRepository)
        {
            this.PatientsRepository = PatientsRepository;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            return (await PatientsRepository.GetAllAsync()).Select(r=>r.Map());
        }

        public IEnumerable<PatientDto> GetByAppointmentDate(DateTime appointmentDate)
        {
            return PatientsRepository.GetByAppointmentDate(appointmentDate)?.Select(ld=>ld.Map());
        }
    }
}
