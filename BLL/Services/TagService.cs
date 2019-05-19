using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;


namespace BLL.Services
{
    public class TagService : ITagService
    {
        IUnitOfWork db { get; set; }

        public TagService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<TagDTO> GetAllTags()
        {
            var tags = db.Tags.GetAll();
            return Mapper.Map<IEnumerable<Tag>, IEnumerable<TagDTO>>(tags);
        }

        public TagDTO GetTag(string name)
        {
            var tag = db.Tags.Get(name);
            return Mapper.Map<Tag, TagDTO>(tag);
        }
    }
}
