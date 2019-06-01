using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITeacherService
    {
        IEnumerable<TeacherSubjectDTO> GetAllSubjectByTeacher(string teacherId);

        void Insert(TeacherSubjectDTO teacherSubjectDto);

        IEnumerable<TeacherSubjectDTO> GetAllSubject();
    }
}