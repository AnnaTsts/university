using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class FacultyServiceService : IFacultyService
    {
        IUnitOfWork db { get; set; }

        public FacultyServiceService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<FacultyDTO> GetAllFacultys()
        {
            IEnumerable<Faculty> faculties = db.Faculties.GetAll();
            return Mapper.Map<IEnumerable<Faculty>, IEnumerable<FacultyDTO>>(faculties);
        }


        public FacultyDTO GetFaculty(int id)
        {
            var faculty = db.Faculties.Get(id);
            return Mapper.Map<Faculty, FacultyDTO>(faculty);
        }

        public void Insert(FacultyDTO faculty)
        {
            db.Faculties.Insert(Mapper.Map<FacultyDTO, Faculty>(faculty));
            db.Save();
        } 
    }
}