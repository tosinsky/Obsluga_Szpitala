namespace DoctorsSelector.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<string> Specializations { get; set; }
    }
}
