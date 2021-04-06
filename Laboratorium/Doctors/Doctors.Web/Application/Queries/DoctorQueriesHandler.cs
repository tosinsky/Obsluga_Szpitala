namespace Doctors.Web.Application
{
    using Doctors.Domain.DoctorAggregate;
    using Doctors.Web.Application.Mapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorQueriesHandler : IDoctorQueriesHandler
    {
        private readonly IDoctorsRepository DoctorsRepository;

        public DoctorQueriesHandler(IDoctorsRepository DoctorsRepository)
        {
            this.DoctorsRepository = DoctorsRepository;
        }

        public IEnumerable<DoctorDto> GetAll()
        {
            return DoctorsRepository.GetAll().Select(r=>r.Map());
        }

        public IEnumerable<DoctorDto> GetByCertificationType(int certificationType)
        {
            return DoctorsRepository.GetByCertificationType(certificationType)?.Select(ld=>ld.Map());
        }
    }
}
