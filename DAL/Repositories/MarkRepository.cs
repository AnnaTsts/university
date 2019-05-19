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
    public class MarkRepository : IRepository<Mark,int>
    {
        private ApplicationDbContext db;

        public MarkRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Mark> Find(Func<Mark, bool> predicate)
        {
            return db.Marks.Where(predicate);
        }

        public Mark Get(int id)
        {
            return db.Marks.Find(id);
        }

        public IEnumerable<Mark> GetAll()
        {
            return db.Marks.ToList();
        }

        public void Insert(Mark obj)
        {
            db.Marks.Add(obj);
        }
    }
}
