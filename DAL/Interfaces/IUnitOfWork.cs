using DAL.Entities;
using DAL.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        IRepository<Chair,int> Chairs { get; }
        
        IRepository<Faculty,int> Faculties { get; }
        
        IRepository<Group,int> Groups { get; }
        
        IRepository<Specialization,int> Specializations { get; }
        
        IRepository<StudentsMark,int> StudentsMarks { get; }
        
        IRepository<Subject,int> Subjects { get; }
        
        IRepository<TeacherSubject,int> TeacherSubjects { get; }
        
        
        void Save();
        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
