using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StudentsMarkRepository:IRepository<StudentsMark,int>
    {
        private ApplicationDbContext db;
        
        public StudentsMarkRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<StudentsMark> GetAll()
        {
            return db.StudentsMarks.ToList();
        }

        public StudentsMark Get(int id)
        {
            return db.StudentsMarks.Find(id);
        }

        public IEnumerable<StudentsMark> Find(Func<StudentsMark, bool> predicate)
        {
            return db.StudentsMarks.Where(predicate);
        }

        public void Insert(StudentsMark obj)
        {
            db.StudentsMarks.Add(obj);
        }
        


        
    }
}