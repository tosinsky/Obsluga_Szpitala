using ExaminationRoomsSelector.Web.Application.Dtos;
using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationRoomsSelector.Web.Controllers
{
    [ApiController]
    public class ExaminationRoomsSelectorController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsSelectorController> logger;
        private readonly IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler;

        public ExaminationRoomsSelectorController(ILogger<ExaminationRoomsSelectorController> logger, IExaminationRoomsSelectorHandler examinationRoomsSelectorHandler)
        {
            this.logger = logger;
            this.examinationRoomsSelectorHandler = examinationRoomsSelectorHandler;
        }

        [HttpGet("examination-rooms-selection")]
        public async Task<int> GetLaboratoryDiagnosticiansDetails()
        {
            return await examinationRoomsSelectorHandler.GetExaminationRoomsSelectionAsync();
        }

        [HttpGet("testowa-doctors")]
        public async Task<IEnumerable<DoctorDto>> GetLaboratoryDiagnosticiansDetailss()
        {
            return await examinationRoomsSelectorHandler.GetDoctorsSelectionAsync();
        }

        [HttpGet("testowa-rooms")]
        public async Task<IEnumerable<ExaminationRoomDto>> GetLaboratoryDiagnosticiansDetailssss()
        {
            return await examinationRoomsSelectorHandler.GetExaminationRoomssSelectionAsync();
        }



        [HttpGet("testowa-słownik")]
        public Task<string> GetLaboratoryDiagnosticiansDetailsss()
        {

            var dictionary = examinationRoomsSelectorHandler.GetDoctorsToRoomsAsync();

            //string json = JsonConverter.SerializeObject(dictionary);
            string json = JsonConvert.SerializeObject(dictionary);

            return Task.FromResult(json);
            //return JsonConvert.SerializeObject(dictionary);
            //return json;
            //return JsonConvert.SerializeObject(dictionary);
            //return await examinationRoomsSelectorHandler.GetDoctorsToRoomsAsync();
        }

    }
}
