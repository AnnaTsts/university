﻿using BLL.DTO;
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
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
                IdentityResult result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new IdentityOperations(false, result.Errors.FirstOrDefault(), "");
                
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
    }
}
