namespace Doctors.Web.Application
{
    using Doctors.Domain.DoctorAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorQueriesHandler
    {
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        IEnumerable<DoctorDto> GetByCertificationType(int certificationType);
    }
}
