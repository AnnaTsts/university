using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        private ChairRepository chairRepository;
        private FacultyRepository facultyRepository;
        private GroupRepository groupRepository;
        private SpecializationRepository specializationRepository;
        private StudentsMarkRepository studentsMarkRepository;
        private SubjectRepository subjectRepository;
        private TeacherSubjectRepository teacherSubjectRepository;


        public ApplicationUserManager UserManager
        {
            get
            {
                if (userManager == null)
                    userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                return userManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                if (roleManager == null)
                    roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
                return roleManager;
            }
        }

        public UnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }
        
        public IRepository<Chair, int> Chairs
        {
            get
            {
                if (chairRepository == null)
                    chairRepository = new ChairRepository(db);
                return chairRepository;
            }
        }

        public IRepository<Faculty, int> Faculties
        {
            get
            {
                if (facultyRepository == null)
                    facultyRepository = new FacultyRepository(db);
                return facultyRepository;
            }
        }

        public IRepository<Group, int> Groups
        {
            get
            {
                if (groupRepository == null)
                    groupRepository = new GroupRepository(db);
                return groupRepository;
            }
        }

        public IRepository<Specialization, int> Specializations
        {
            get
            {
                if (specializationRepository == null)
                    specializationRepository = new SpecializationRepository(db);
                return specializationRepository;
            }
        }

        public IRepository<StudentsMark, int> StudentsMarks
        {
            get
            {
                if (studentsMarkRepository == null)
                    studentsMarkRepository = new StudentsMarkRepository(db);
                return studentsMarkRepository;
            }
        }

        public IRepository<Subject, int> Subjects { get
        {
            if (subjectRepository == null)
                subjectRepository = new SubjectRepository(db);
            return subjectRepository;
        } }
        public IRepository<TeacherSubject, int> TeacherSubjects {get
        {
            if (teacherSubjectRepository == null)
                teacherSubjectRepository = new TeacherSubjectRepository(db);
            return teacherSubjectRepository;
        } }


        
        
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}