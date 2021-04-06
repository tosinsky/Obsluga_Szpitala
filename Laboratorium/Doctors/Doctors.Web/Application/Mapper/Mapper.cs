namespace Doctors.Web.Application.Mapper
{
    using Doctors.Domain.DoctorAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Mapper
    {
        public static DoctorDto Map(this Doctor Doctor)
        {
            if (Doctor == null)
                return null;

            return new DoctorDto
            {
                Number = Doctor.Number,
                Certifications = Doctor?.Certifications.Select(s => s.Type)
            };
        }
    }
}
