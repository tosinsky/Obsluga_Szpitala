using DoctorsSelector.Web.Application.DataServiceClients;
using DoctorsSelector.Web.Application.Dtos;
using DoctorsSelector.Web.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsSelector.Web.Controllers
{
    [ApiController]
    public class DoctorsSelectorController : ControllerBase
    {
        private readonly ILogger<DoctorsSelectorController> logger;
        private readonly IDoctorsSelectorHandler doctorsSelectorHandler;

        public DoctorsSelectorController(ILogger<DoctorsSelectorController> logger, IDoctorsSelectorHandler doctorsSelectorHandler)
        {
            this.logger = logger;
            this.doctorsSelectorHandler = doctorsSelectorHandler;
        }
        [HttpGet("doctors-list")]
        public async Task<IEnumerable<DoctorDto>> GetLaboratoryDiagnosticiansDetailss()
        {
            return await doctorsSelectorHandler.GetDoctorsSelectionAsync();
        }
    }
}
