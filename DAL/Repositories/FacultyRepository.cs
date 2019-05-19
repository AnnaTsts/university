using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class FacultyRepository:IRepository<Faculty,int>
    {
        private ApplicationDbContext db;
        
        public FacultyRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<Faculty> GetAll()
        {
            return db.Facultys.ToList();
        }

        public Faculty Get(int id)
        {
            return db.Facultys.Find(id);
        }

        public IEnumerable<Faculty> Find(Func<Faculty, bool> predicate)
        {
            return db.Facultys.Where(predicate);
        }

        public void Insert(Faculty obj)
        {
            db.Facultys.Add(obj);
        }
    }
}