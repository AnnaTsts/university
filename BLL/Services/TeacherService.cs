using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TeacherService : ITeacherService
    {
        
        IUnitOfWork db { get; set; }

        public TeacherService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<TeacherSubjectDTO> GetAllSubjectByTeacher(string teacherId)
        {
            var subjects = db.TeacherSubjects.Find((ts) => ts.TeacherId == teacherId);
            return Mapper.Map<IEnumerable<TeacherSubject>, IEnumerable<TeacherSubjectDTO>>(subjects);
        }

        public void Insert(TeacherSubjectDTO teacherSubjectDto)
        {
            db.TeacherSubjects.Insert(Mapper.Map<TeacherSubjectDTO, TeacherSubject>(teacherSubjectDto));
            db.Save();
        }
        
        
    }
}