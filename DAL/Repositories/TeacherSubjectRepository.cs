using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TeacherSubjectRepository:IRepository<TeacherSubject,int>
    {
        private ApplicationDbContext db;

        public TeacherSubjectRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public TeacherSubject Get(int id)
        {
            throw new NotImplementedException();
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
            //Console.WriteLine("start");
            return db.TeacherSubjects.ToList();
            
        }

        public void Insert(TeacherSubject obj)
        {
            db.TeacherSubjects.Add(obj);
        }
    }
}