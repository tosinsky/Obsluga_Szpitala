namespace DoctorsSelector.Web.Application.Queries
{ 
    using DoctorsSelector.Web.Application.DataServiceClients;
    using DoctorsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorsSelectorQueryHandler : IDoctorsSelectorHandler
    {
        private readonly IDoctorsServiceClient doctorsServiceClient;

        public DoctorsSelectorQueryHandler(IDoctorsServiceClient doctorsServiceClient)
        {
            this.doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsSelectionAsync()
        {
            var doctors = doctorsServiceClient.GetAllDoctorsAsync();

            return await doctorsServiceClient.GetAllDoctorsAsync();
        }
    }
}
