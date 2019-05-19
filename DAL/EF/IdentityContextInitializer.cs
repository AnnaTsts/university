using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;
using System.Data.Entity.Validation;

namespace DAL.EF
{
    public class IdentityContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {

            Faculty faculty = new Faculty{Name = "FIOT"};
         
            Chair chair = new Chair{Name = "ASOIY",Faculty = faculty};
            Chair chair2 = new Chair{Name = "OT",Faculty = faculty};
            
            Specialization specialization = new Specialization{Name = "121 Program Ingeniryng"};
            Group group = new Group{Name = "IP-61",Specialization = specialization};

            Subject subject =new Subject{Name = "Math"};
            
            ApplicationUser teacher= new ApplicationUser{UserName = "kek",FirstName = "Ivan",SecondName = "Ivanov",Chair = chair,Email = "iv@iv", Group = group};
            ApplicationUser student= new ApplicationUser{UserName = "Lol",FirstName = "Petro",SecondName = "Petrov",Chair = chair,Email = "petr@petrov",Group = group};


            TeacherSubject tc = new TeacherSubject {Teacher =teacher,Group = group,Subject = subject};
            
            StudentsMark studentsMark =new StudentsMark{TeacherSubject = tc,Student = student,Mark=100};

            group.Specialization = specialization;
            group.Faculty = faculty;
            group.Students = new List<ApplicationUser>{student};
                


            Book Moon = new Book { Name = "Moon", Text = "legendary"};
            Book Sao = new Book { Name = "Sao", Text = "sword"};
            Book Rihter = new Book { Name = "Rihter", Text = "sharp"};
            Book Sf = new Book { Name = "Shadow", Text = "sfdot"};

            Tag adv = new Tag { Name = "adventure", Books = new List<Book> { Moon, Sao } };
            Tag science = new Tag { Name = "science", Books = new List<Book> { Rihter, Moon } };
            //Tag soul = new Tag { Id = 1, Name = "soul" , Books = new List<Book> { Moon } };
            Tag soul = new Tag { Name = "soul", Books = new List<Book> { Moon, Sf } };

           // ApplicationUser andr = new ApplicationUser {  FirstName = "dgs" , SecondName = "eeee",Email = "a@a.com" , UserName = "shatr"};
           // ApplicationUser vania = new ApplicationUser { FirstName = "dgs", SecondName = "ee", Email = "v@v.com", UserName = "shava"};

           // Mark andrMoon = new Mark { ApplicationUser = andr, Book = Moon, Value = 10 };


           // Moon.ApplicationUser = andr;
           // Sao.ApplicationUser = andr;
           // Rihter.ApplicationUser = vania;
           // Sf.ApplicationUser = vania;


           // context.Books.AddRange(new List<Book> { Moon, Sao, Rihter, Sf });
           // context.Marks.Add(andrMoon);
           // context.Tags.AddRange(new List<Tag> { adv, science, soul });
           // context.Users.Add(andr);
           // context.Users.Add(vania);

            context.Chairs.Add(chair);
            context.Chairs.Add(chair2);
            context.Facultys.Add(faculty);
            context.Groups.Add(group);
            context.Specializations.Add(specialization);
            context.ApplicationUsers.Add(student);
            context.ApplicationUsers.Add(teacher);
            context.StudentsMarks.Add(studentsMark);
            context.TeacherSubjects.Add(tc);

            
            

            string er = "";
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    er += "Entity of type" + eve.Entry.Entity.GetType().Name + "in state" + eve.Entry.State+" has the following validation errors:" ;
                    foreach (var ve in eve.ValidationErrors)
                    {
                        er += "\n + Property - " + ve.PropertyName + " Error - " + ve.ErrorMessage;
                    }
                }
                throw;
            }


            

            
            base.Seed(context);
        }
    }
}
