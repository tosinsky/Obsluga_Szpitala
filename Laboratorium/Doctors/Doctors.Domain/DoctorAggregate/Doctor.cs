namespace Doctors.Domain.DoctorAggregate
{
    using Doctors.Domain.SeedWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Doctor : Entity
    {
        public string Number { get; private set; }
        public IList<Certification> Certifications { get; private set; } = new List<Certification>();

        public Doctor(int id, string number) : base(id)
        {
            Number = number;
        }

        public Doctor(int id, string number, IList<Certification> certifications) : this(id, number)
        {
            Certifications = certifications;
        }

        public void AddCertification(Certification certification)
        {
            Certifications.Add(certification);
        }
    }
}
