namespace Doctors.Infrastructure
{
    using Doctors.Domain;
    using Doctors.Domain.DoctorAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DoctorsRepository : IDoctorsRepository
    {
        private static readonly Doctor[] Doctors = new Doctor[]
        {
            new Doctor(1, "Halat", new List<Certification>{ new Certification(69, DateTime.UtcNow, 1)}),      
            new Doctor(2, "02"),
            new Doctor(3, "03", new List<Certification>{new Certification(2, DateTime.UtcNow, 5),new Certification(3, DateTime.UtcNow, 7)}),
            new Doctor(4, "101", new List<Certification>{ new Certification(4, DateTime.UtcNow, 6),new Certification(5, DateTime.UtcNow, 3),new Certification(6, DateTime.UtcNow, 5)}),
            new Doctor(5, "102", new List<Certification>{ new Certification(7, DateTime.UtcNow, 3),new Certification(8, DateTime.UtcNow, 2)}),
            new Doctor(6, "103", new List<Certification>{ new Certification(9, DateTime.UtcNow, 2),new Certification(10, DateTime.UtcNow, 1),new Certification(11, DateTime.UtcNow, 5)}),
            new Doctor(7, "104", new List<Certification>{ new Certification(12, DateTime.UtcNow, 5)}),
            new Doctor(8, "105a", new List<Certification>{ new Certification(13, DateTime.UtcNow, 12)}),
            new Doctor(9, "105b", new List<Certification>{ new Certification(14, DateTime.UtcNow, 7),new Certification(15, DateTime.UtcNow, 6),new Certification(16, DateTime.UtcNow, 5)}),
            new Doctor(10, "201", new List<Certification>{ new Certification(17, DateTime.UtcNow, 9),new Certification(18, DateTime.UtcNow, 7),new Certification(19, DateTime.UtcNow, 8)}),
            new Doctor(11, "202", new List<Certification>{ new Certification(20, DateTime.UtcNow, 10),new Certification(21, DateTime.UtcNow, 1)}),
            new Doctor(12, "203", new List<Certification>{ new Certification(22, DateTime.UtcNow, 1)}),
            new Doctor(13, "204a", new List<Certification>{ new Certification(23, DateTime.UtcNow, 4)}),
            new Doctor(14, "204b", new List<Certification>{ new Certification(24, DateTime.UtcNow, 7),new Certification(25, DateTime.UtcNow, 6)}),
            new Doctor(15, "301", new List<Certification>{ new Certification(26, DateTime.UtcNow, 6),new Certification(27, DateTime.UtcNow, 5)}),
            new Doctor(16, "302", new List<Certification>{ new Certification(28, DateTime.UtcNow, 5),new Certification(29, DateTime.UtcNow, 4)}),
            new Doctor(17, "303", new List<Certification>{ new Certification(30, DateTime.UtcNow, 5),new Certification(31, DateTime.UtcNow, 3)}),
            new Doctor(18, "401", new List<Certification>{ new Certification(32, DateTime.UtcNow, 8),new Certification(33, DateTime.UtcNow, 1),new Certification(34, DateTime.UtcNow, 2)}),
            new Doctor(19, "402"),
            new Doctor(20, "403", new List<Certification>{ new Certification(35, DateTime.UtcNow, 10)})
        };

        public IEnumerable<Doctor> GetAll ()
        {
            return Doctors;
        }

        public IEnumerable<Doctor> GetByCertificationType(int certificationType) 
        {
            return Doctors?.Where(ld => ld.Certifications.Any(s => s.Type == certificationType));
        }
    }
}
