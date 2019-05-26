using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SpecializationService 
    {
        IUnitOfWork db { get; set; }

        public SpecializationService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<SpecializationDTO> GetAllSpecializations()
        {
            IEnumerable<Specialization> specializations = db.Specializations.GetAll();
            return Mapper.Map<IEnumerable<Specialization>, IEnumerable<SpecializationDTO>>(specializations);
        }


        public SpecializationDTO GetSpecialization(int id)
        {
            var specialization = db.Specializations.Get(id);
            return Mapper.Map<Specialization, SpecializationDTO>(specialization);
        }

        public void Insert(SpecializationDTO specialization)
        {
            db.Specializations.Insert(Mapper.Map<SpecializationDTO, Specialization>(specialization));
            db.Save();
        }

    }
}