namespace Patients.Domain.PatientAggregate
{
    using Patients.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Appointment : Entity
    {
        public DateTime AppointmentDate { get; private set; }
        public string Reason { get; private set; }
        public Appointment(int id, DateTime appointmentdate, string reason) : base(id)
        {
            AppointmentDate = appointmentdate;
            Reason = reason; 
        }
    }
}
