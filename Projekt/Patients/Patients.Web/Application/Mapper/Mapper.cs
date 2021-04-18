 
﻿namespace Patients.Web.Application.Mapper
{
    using Patients.Domain.PatientAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static PatientDto Map(this Patient Patient)
        {
            if (Patient == null)
                return null;

            return new PatientDto
            {
                Name = Patient.Name,
                Surname = Patient.Surname,
                PESEL = Patient.PESEL,
                PhoneNumber = Patient.PhoneNumber,
                Birthdate = Patient.Birthdate,
                Appointments = Patient?.Appointments.Select(s => s.AppointmentDate + " " + s.Reason)
            };
        }
    }
}
