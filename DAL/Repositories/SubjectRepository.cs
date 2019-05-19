using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class SubjectRepository:IRepository<Subject,int>
    {
        private ApplicationDbContext db;
        
        public SubjectRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<Subject> GetAll()
        {
            return db.Subjects.ToList();
        }

        public Subject Get(int id)
        {
            return db.Subjects.Find(id);
        }

        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return db.Subjects.Where(predicate);
        }

        public void Insert(Subject obj)
        {
            db.Subjects.Add(obj);
        }

        
    }
}