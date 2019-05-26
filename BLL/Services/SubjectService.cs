using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SubjectService
    {
        IUnitOfWork db { get; set; }

        public SubjectService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<SubjectDTO> GetAllSubjects()
        {
            IEnumerable<Subject> faculties = db.Subjects.GetAll();
            return Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDTO>>(faculties);
        }


        public SubjectDTO GetSubject(int id)
        {
            var subject = db.Subjects.Get(id);
            return Mapper.Map<Subject, SubjectDTO>(subject);
        }

        public void Insert(SubjectDTO subject)
        {
            db.Subjects.Insert(Mapper.Map<SubjectDTO, Subject>(subject));
            db.Save();
        } 
    }
}