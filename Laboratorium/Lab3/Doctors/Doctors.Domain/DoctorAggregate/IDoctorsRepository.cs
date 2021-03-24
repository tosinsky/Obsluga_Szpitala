namespace Doctors.Domain.DoctorAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IDoctorsRepository
    {
        IEnumerable<Doctor> GetAll();
        IEnumerable<Doctor> GetByCertificationType(int certificationType);
    }
}
