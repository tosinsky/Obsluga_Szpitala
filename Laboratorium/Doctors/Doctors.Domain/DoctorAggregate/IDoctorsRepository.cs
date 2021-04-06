namespace Doctors.Domain.DoctorAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IDoctorsRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        IEnumerable<Doctor> GetByCertificationType(int certificationType);
        Task AddDoctorAsync(Doctor examinationRoom);
    }
}
