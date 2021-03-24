namespace Doctors.Web.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public string Number { get; set; }
        public IEnumerable<string> Certifications { get; set; }
    }
}
