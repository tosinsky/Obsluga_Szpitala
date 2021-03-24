namespace ExaminationRoomsSelector.Web.Application.Queries
{
    using ExaminationRoomsSelector.Web.Application.DataServiceClients;
    using ExaminationRoomsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomsSelectorQueryHandler : IExaminationRoomsSelectorHandler
    {
        private readonly IExaminationRoomsServiceClient examinationRoomsServiceClient;
        private readonly IDoctorsServiceClient doctorsServiceClient;

        public ExaminationRoomsSelectorQueryHandler(IExaminationRoomsServiceClient examinationRoomsServiceClient, IDoctorsServiceClient doctorsServiceClient)
        {
            this.examinationRoomsServiceClient = examinationRoomsServiceClient;
            this.doctorsServiceClient = doctorsServiceClient;
        }

        public async Task<int> GetExaminationRoomsSelectionAsync()
        {  
            var doctors = doctorsServiceClient.GetAllDoctorsAsync();

            //return doctorsServiceClient.GetAllDoctors().Count();
            return (await examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).Count();
        }

        public async Task<IEnumerable<ExaminationRoomDto>> GetExaminationRoomssSelectionAsync()
        {
            var doctors = doctorsServiceClient.GetAllDoctorsAsync();

            //return doctorsServiceClient.GetAllDoctors().Count();
            return await examinationRoomsServiceClient.GetAllExaminationRoomsAsync();
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsSelectionAsync()
        {
            var doctors = doctorsServiceClient.GetAllDoctorsAsync();

            //return doctors.ToString;
            return await doctorsServiceClient.GetAllDoctorsAsync();
            //return (await examinationRoomsServiceClient.GetAllExaminationRoomsAsync()).Count();
        }

        public Task<Dictionary<ExaminationRoomDto, DoctorDto>> GetDoctorsToRoomsAsync()
        {
            var doctors = doctorsServiceClient.GetAllDoctorsAsync();

            List<DoctorDto> doctorsList = new List<DoctorDto>();
            foreach (var doctor in doctors.Result)
            {
                doctorsList.Add(doctor);
            }

            var examinationRooms = examinationRoomsServiceClient.GetAllExaminationRoomsAsync();

            List<ExaminationRoomDto> examinationRoomsList = new List<ExaminationRoomDto>();
            foreach (var room in examinationRooms.Result)
            {
                examinationRoomsList.Add(room);
            };

            Dictionary<ExaminationRoomDto, DoctorDto> assignments = new Dictionary<ExaminationRoomDto, DoctorDto>();

            assignments.Add(examinationRoomsList[0], doctorsList[0]);
            assignments.Add(examinationRoomsList[1], doctorsList[1]);
            assignments.Add(examinationRoomsList[2], doctorsList[2]);
            assignments.Add(examinationRoomsList[3], doctorsList[3]);

            //Console.WriteLine(examinationRoomsList);
            //Console.WriteLine(doctorsList);
            return Task.FromResult(assignments);
            //return assignments;
            //return await assignments;
        }


    }
}
