using System;
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
            Console.WriteLine(teacherId);
            var subjects = db.TeacherSubjects.Find((ts) => ts.TeacherId == teacherId);
            Console.WriteLine("end");
            Console.WriteLine(subjects.ToString());
            return Mapper.Map<IEnumerable<TeacherSubject>, IEnumerable<TeacherSubjectDTO>>(subjects);
        }
        
        public IEnumerable<TeacherSubjectDTO> GetAllSubject()
        {

            var subjects = db.TeacherSubjects.GetAll();
            Console.WriteLine(subjects.ToString());
            return Mapper.Map<IEnumerable<TeacherSubject>, IEnumerable<TeacherSubjectDTO>>(subjects);
        }

        public void Insert(TeacherSubjectDTO teacherSubjectDto)
        {
            db.TeacherSubjects.Insert(Mapper.Map<TeacherSubjectDTO, TeacherSubject>(teacherSubjectDto));
            db.Save();
        }
        
        
    }
}