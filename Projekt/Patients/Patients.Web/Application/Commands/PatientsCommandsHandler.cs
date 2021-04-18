namespace Patients.Web.Application.Commands
{
    using Patients.Domain.PatientAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientsCommandsHandler : ICommandHandler<AddPatientCommand>
    {
        private readonly IPatientsRepository PatientsRepository;

        public PatientsCommandsHandler(IPatientsRepository PatientsRepository) 
        {
            this.PatientsRepository = PatientsRepository;
        }

        public void Handle(AddPatientCommand command)
        {
            var appointments = new List<Appointment>();

            foreach  (var appointment in command.Appointments)
                appointments.Add(new Appointment(0, DateTime.UtcNow, appointment.ToString()));

            PatientsRepository.AddPatientAsync(new Patient(0,command.Name,command.Surname,command.PESEL,command.PhoneNumber,command.Birthdate,appointments));
        }
    }
}
