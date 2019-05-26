using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ISpecializationService
    {
        IEnumerable<SpecializationDTO> GetAllSpecializations();

        SpecializationDTO GetSpecialization(int id);
    }
}