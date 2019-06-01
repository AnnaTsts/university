using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<SubjectDTO> GetAllSubjects();

        SubjectDTO GetSubject(int id);

        void Insert(SubjectDTO subject);
    }
}