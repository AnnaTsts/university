using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class TagRepository : IRepository<Tag,string>
    {
        private ApplicationDbContext db;

        public TagRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            return db.Tags.Where(predicate);
        }

        public Tag Get(string name)
        {
            return db.Tags.Find(name);
        }

        public IEnumerable<Tag> GetAll()
        {
            return db.Tags.ToList();
        }

        public void Insert(Tag obj)
        {
            db.Tags.Add(obj);
        }
    }
}
