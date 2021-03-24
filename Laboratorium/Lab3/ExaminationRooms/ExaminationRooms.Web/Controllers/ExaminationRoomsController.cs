﻿namespace ExaminationRooms.Web.Controllers
{
    using ExaminationRooms.Domain;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Web.Application;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    public class ExaminationRoomsController : ControllerBase
    {
        private readonly ILogger<ExaminationRoomsController> logger;
        private readonly IExaminationRoomQueriesHandler examinationRoomQueriesHandler;

        public ExaminationRoomsController(ILogger<ExaminationRoomsController> logger, IExaminationRoomQueriesHandler examinationRoomQueriesHandler)
        {
            this.logger = logger;
            this.examinationRoomQueriesHandler = examinationRoomQueriesHandler;
    }

        [HttpGet("examination-rooms")]
        public IEnumerable<ExaminationRoomDto> GetAll()
        {
            return examinationRoomQueriesHandler.GetAll();
        }

        [HttpGet("examination-room")]
        public IEnumerable<ExaminationRoomDto> GetBySpecialization([FromQuery] int certificationType)
        {
            return examinationRoomQueriesHandler.GetByCertificationType(certificationType);
        }
    }
}
