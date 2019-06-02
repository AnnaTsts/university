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
        
        public bool Update(int id, StudentsMark newObj)
        {
            StudentsMark oldStudMark = Get(id);

            if (oldStudMark == null)
            {
                Insert(newObj);
               // return false;
            }

            oldStudMark.Mark = newObj.Mark;
            
          //  oldStudMark = MapMark(oldStudMark, newObj);
            return true;
        }
        
        
        private StudentsMark MapMark(StudentsMark oldMark, StudentsMark newMark)
        {
            oldMark.NameOfWork = newMark.NameOfWork;
            oldMark.Mark = newMark.Mark;
            return oldMark;
        }


        
    }
}