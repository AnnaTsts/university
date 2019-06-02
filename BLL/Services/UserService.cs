using System;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IdentityOperations> CreateUserAsync(UserDTO userDto)
        {
            var user = await Database.UserManager.FindByEmailAsync(userDto.UserName);
            if (user == null)
            {
                Console.WriteLine("flag");
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName ,FirstName = userDto.FirstName,SecondName = userDto.SecondName ,GroupId = 1,ChairId = 1};
                Console.WriteLine("User was created");
                Console.WriteLine(user.Id);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.UserName);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.SecondName);
    
                IdentityResult result = await Database.UserManager.CreateAsync(user, userDto.Password);
                Console.WriteLine("Database:User was created");

                if (result.Errors.Count() > 0)
                {
                    Console.WriteLine("WE ARE HERE");
                    return new IdentityOperations(false, result.Errors.FirstOrDefault(), "");
                }

                await Database.SaveAsync();
                return new IdentityOperations(true, "Registration successfully completed", "");
            }
            else
            {
                return new IdentityOperations(false, "User with this email already exists", "Email");
            }
        }


        public async Task<ApplicationUser> FindUserAsync(string userName, string password)
        {
            var user = await Database.UserManager.FindAsync(userName, password);
            return user;
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public async void GetSumm(SummaryInfo sum , string uname)
        {
            var user = Database.UserManager.FindByNameAsync(uname);
            ApplicationUser applicationUser = user.Result; 
            //sum.Id = user.Id;
            if (applicationUser != null)
            {
                sum.FirstName = applicationUser.FirstName;
                sum.SecondName = applicationUser.SecondName;
                sum.ChairId = applicationUser.ChairId;
                sum.GroupId = applicationUser.GroupId;
                sum.Email = applicationUser.Email;
                
                Group g = Database.Groups.Get(sum.GroupId);
                if (g != null)
                {
                    sum.GroupName = g.Name;
                    sum.SpecializationName = g.Specialization.Name;
                    sum.FacultyName = g.Faculty.Name;
                }

                Chair c = Database.Chairs.Get(sum.ChairId);
                if(c!=null)
                    sum.ChairName = c.Name;
            }
            
        }
        
        
    }
}

