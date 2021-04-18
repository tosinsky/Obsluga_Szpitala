namespace DoctorsSelector.Web.Application.Queries
{
    using DoctorsSelector.Web.Application.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDoctorsSelectorHandler
    {
        Task<IEnumerable<DoctorDto>> GetDoctorsSelectionAsync();
    }
}

