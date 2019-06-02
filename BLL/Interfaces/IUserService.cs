using BLL.DTO;
using BLL.Infrastructure;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IDisposable
    {

        Task<IdentityOperations> CreateUserAsync(UserDTO userDto);

        Task<ApplicationUser> FindUserAsync(string userName, string password);
        void GetSumm(SummaryInfo sum, string uname);
    }
}
