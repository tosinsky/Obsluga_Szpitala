namespace Doctors.Web.Controllers
{
    using Doctors.Domain;
    using Doctors.Domain.DoctorAggregate;
    using Doctors.Web.Application;
    using Doctors.Web.Application.Commands;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ILogger<DoctorsController> logger;
        private readonly IDoctorQueriesHandler DoctorQueriesHandler;
        private readonly ICommandHandler<AddDoctorCommand> addDoctorCommandHandler;

        public DoctorsController(ILogger<DoctorsController> logger, IDoctorQueriesHandler DoctorQueriesHandler, ICommandHandler<AddDoctorCommand> addDoctorCommandHandler)
        {
            this.logger = logger;
            this.DoctorQueriesHandler = DoctorQueriesHandler;
            this.addDoctorCommandHandler = addDoctorCommandHandler;
    }

        [HttpGet("doctors")]
        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            return await DoctorQueriesHandler.GetAllAsync();
        }

        [HttpGet("doctor")]
        public IEnumerable<DoctorDto> GetBySpecialization([FromQuery] int certificationType)
        {
            return DoctorQueriesHandler.GetByCertificationType(certificationType);
        }

        [HttpPost("doctor")]
        public void AddDoctor([FromBody] AddDoctorCommand DoctorCommand)
        {
            addDoctorCommandHandler.Handle(DoctorCommand);
        }
    }
}
