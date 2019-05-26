using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ChairService : IChairService
    {
        IUnitOfWork db { get; set; }

        public ChairService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<ChairDTO> GetAllChairs()
        {
            IEnumerable<Chair> chairs = db.Chairs.GetAll();
            return Mapper.Map<IEnumerable<Chair>, IEnumerable<ChairDTO>>(chairs);
        }


        public ChairDTO GetChair(int id)
        {
            var chair = db.Chairs.Get(id);
            return Mapper.Map<Chair, ChairDTO>(chair);
        }

        public void Insert(ChairDTO chair)
        {
            db.Chairs.Insert(Mapper.Map<ChairDTO, Chair>(chair));
            db.Save();
        }

    }
}