using DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(string connectionStr) : base(connectionStr)
        {
        }

        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new IdentityContextInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Mark> Marks { get; set; }
        
        
        public DbSet<Chair> Chairs { get; set; }
        
        public DbSet<Faculty> Facultys { get; set; }
        
        public DbSet<Group> Groups { get; set; }
        
        public DbSet<Specialization> Specializations { get; set; }
        
        public DbSet<StudentsMark> StudentsMarks { get; set; }
        
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        
        public DbSet<Subject> Subjects { get; set; }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        

        
        
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chair>().ToTable("Chair");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Specialization>().ToTable("Specialization");
            modelBuilder.Entity<StudentsMark>().ToTable("StudentsMark");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<TeacherSubject>().ToTable("TeacherSubject");
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<Mark>().ToTable("Mark");


            //modelBuilder.Entity<Book>().HasMany(b => b.)
            modelBuilder.Entity<Book>().HasMany(b => b.Marks).WithRequired(m => m.Book).WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasMany(g=>g.Students).WithRequired(u=>u.Group).WillCascadeOnDelete(false);
            modelBuilder.Entity<StudentsMark>().Property(sm => sm.Date).HasColumnType("datetime2");
            modelBuilder.Entity<TeacherSubject>().Property(ts => ts.StartTime).HasColumnType("datetime2");
            modelBuilder.Entity<TeacherSubject>().Property(ts => ts.EndTime).HasColumnType("datetime2");
            
        }
        
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
    
                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);
    
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
    
                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

    }
}
