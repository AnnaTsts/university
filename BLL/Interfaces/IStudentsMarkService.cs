using System.Collections.Generic;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IStudentsMarkService
    {
        IEnumerable<StudentsMarkDTO> GetAllMarks();

        StudentsMarkDTO GetMark(int id);
        
        void Insert(StudentsMarkDTO studentsMark);

        IEnumerable<StudentsMarkDTO> GetAllMarksByGroup(int groupId);
        
        IEnumerable<StudentsMarkDTO> GetAllMarksByTeacher(string teacherId);
        
        IEnumerable<StudentsMarkDTO> GetAllMarksByStudent(string userId);

        IEnumerable<StudentsMarkDTO> GetAllMarksByTeacherAndGroup(string userId, int groupId);
    }
}