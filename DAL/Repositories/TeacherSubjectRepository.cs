using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TeacherSubjectRepository:IRepository<TeacherSubject,string>
    {
        private ApplicationDbContext db;

        public TeacherSubjectRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<TeacherSubject> Find(Func<TeacherSubject, bool> predicate)
        {
            return db.TeacherSubjects.Where(predicate);
        }

        public TeacherSubject Get(string name)
        {
            return db.TeacherSubjects.Find(name);
        }

        public IEnumerable<TeacherSubject> GetAll()
        {
            return db.TeacherSubjects.ToList();
        }

        public void Insert(TeacherSubject obj)
        {
            db.TeacherSubjects.Add(obj);
        }
    }
}