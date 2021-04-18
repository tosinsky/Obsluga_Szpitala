namespace Patients.Domain.PatientAggregate
{
    using Patients.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Patient : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long PESEL { get; private set; }
        public int PhoneNumber { get; private set; }
        public DateTime Birthdate { get; private set; }
 
        public IList<Appointment> Appointments { get; private set; } = new List<Appointment>();

        public Patient(int id, string name, string surname, long pesel, int phonenumber, DateTime birthdate) : base(id)
        {
            Name = name;
            Surname = surname;
            PESEL = pesel;
            PhoneNumber = phonenumber;
            Birthdate = birthdate;
        }

        public Patient(int id, string name, string surname, long pesel, int phonenumber, DateTime birthdate, IList<Appointment> appointments) : this(id, name, surname, pesel, phonenumber, birthdate)
        {
            Appointments = appointments;
        }

        public void AddAppointment(Appointment apppointment)
        {
            Appointments.Add(apppointment);
        }
        public void AddAppointments(IEnumerable<Appointment> appointments)
        {
            foreach(var appointment in appointments)
                Appointments.Add(appointment);
        }
    }
}
