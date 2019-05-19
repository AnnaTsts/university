using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SpecializationRepository:IRepository<Specialization,int>
    {
        private ApplicationDbContext db;
        
        public SpecializationRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<Specialization> GetAll()
        {
            return db.Specializations.ToList();
        }

        public Specialization Get(int id)
        {
            return db.Specializations.Find(id);
        }

        public IEnumerable<Specialization> Find(Func<Specialization, bool> predicate)
        {
            return db.Specializations.Where(predicate);
        }

        public void Insert(Specialization obj)
        {
            db.Specializations.Add(obj);
        }

        
    }
}