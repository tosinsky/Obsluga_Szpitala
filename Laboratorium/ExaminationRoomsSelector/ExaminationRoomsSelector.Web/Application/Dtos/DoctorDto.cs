namespace ExaminationRoomsSelector.Web.Application.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DoctorDto
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}
