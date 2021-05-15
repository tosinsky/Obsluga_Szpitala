namespace Patients.Web.Controllers
{
    using Patients.Domain;
    using Patients.Domain.PatientAggregate;
    using Patients.Web.Application;
    using Patients.Web.Application.Commands;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Patients.Infrastructure;

    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> logger;
        private readonly IPatientQueriesHandler PatientQueriesHandler;
        private readonly ICommandHandler<AddPatientCommand> addPatientCommandHandler;
        public PatientsController(ILogger<PatientsController> logger, IPatientQueriesHandler PatientQueriesHandler, ICommandHandler<AddPatientCommand> addPatientCommandHandler)
        {
            this.logger = logger;
            this.PatientQueriesHandler = PatientQueriesHandler;
            this.addPatientCommandHandler = addPatientCommandHandler;
        }

        [HttpGet("patients-list")]
        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            return await PatientQueriesHandler.GetAllAsync();
        }

        [HttpGet("patient-by-appointmetDate")]
        public IEnumerable<PatientDto> GetByAppointmentDate([FromQuery] DateTime appointmentDate)
        {
            return PatientQueriesHandler.GetByAppointmentDate(appointmentDate);
        }

        [HttpGet("patient-by-surname")]
        public IEnumerable<PatientDto> GetBySurname([FromQuery] String surname)
        {
            return PatientQueriesHandler.GetBySurname(surname);
        }

        //[HttpPost("addPatient")]
        //public void AddPatient([FromBody] AddPatientCommand PatientCommand)
        //{
        //    addPatientCommandHandler.Handle(PatientCommand);
        //}
        [HttpPost]
        [Route("AddPatient")]
        public void AddPatient(int Id, string Name, string Surname, long PESEL, int PhoneNumber, DateTime Birthdate)
        {
            IPatientsRepository patientRepository = new PatientsRepository() as IPatientsRepository;
            Patient patient = new Patient(8, Name, Surname, PESEL, PhoneNumber, Birthdate);

            patientRepository.AddPatientAsync(patient);
        }
    }
}
