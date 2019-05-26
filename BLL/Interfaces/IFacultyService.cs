using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IFacultyService
    {
        IEnumerable<FacultyDTO> GetAllFacultys();

        FacultyDTO GetFaculty(int id);

        void Insert(FacultyDTO faculty);
    }
}