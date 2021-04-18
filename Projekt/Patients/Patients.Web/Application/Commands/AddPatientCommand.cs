namespace Patients.Web.Application.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    //wykorzystujemy interfejs wskaźnikowy ICommand do jawnego wskazania, że dana klasa jest komendą
    public class AddPatientCommand : ICommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PESEL { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public IEnumerable<int> Appointments { get; set; }
    }
}
