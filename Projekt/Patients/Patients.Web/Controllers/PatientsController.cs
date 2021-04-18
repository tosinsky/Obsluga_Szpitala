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

        [HttpGet("patients")]
        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            return await PatientQueriesHandler.GetAllAsync();
        }

        [HttpGet("patient")]
        public IEnumerable<PatientDto> GetBySpecialization([FromQuery] DateTime appointmentDate)
        {
            return PatientQueriesHandler.GetByAppointmentDate(appointmentDate);
        }

        [HttpPost("addPatient")]
        public void AddPatient([FromBody] AddPatientCommand PatientCommand)
        {
            addPatientCommandHandler.Handle(PatientCommand);
        }
    }
}
