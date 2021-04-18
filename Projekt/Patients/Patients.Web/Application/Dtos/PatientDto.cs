namespace Patients.Web.Application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PESEL { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<string> Appointments { get; set; }
    }
}
