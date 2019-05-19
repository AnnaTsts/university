using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Repositories
{
    public class ChairRepository:IRepository<Chair,int>
    {
        private ApplicationDbContext db;

        public ChairRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<Chair> GetAll()
        {
            return db.Chairs.ToList();
        }

        public Chair Get(int id)
        {
            return db.Chairs.Find(id);
        }

        public IEnumerable<Chair> Find(Func<Chair, bool> predicate)
        {
            return db.Chairs.Where(predicate);
        }

        public void Insert(Chair obj)
        {
            db.Chairs.Add(obj);
        }
    }
}