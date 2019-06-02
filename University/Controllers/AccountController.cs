using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using University.Models;
using System.Web;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using WebApiApp.Filters;
using System;
using System.Data.Entity.Validation;

namespace UIWebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        public IUserService UserService => Request.GetOwinContext().GetUserManager<IUserService>();

        [ModelValidation]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterModel model)
        {
            ChairDTO ch = new ChairDTO{Id=12,Name = "Test",FacultyId = 4,Faculty = new FacultyDTO{Id=4,Name = "ert"}};
            IdentityOperations operationDetails;
            UserDTO userDto = new UserDTO
            {
             //   Chair = ch,
                GroupId = 1,
                ChairId = 1,
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName,
                FirstName = "rr",
                SecondName = "rr",
                
            };
            Console.WriteLine(userDto.Email);
            Console.WriteLine(userDto.Password);
            Console.WriteLine(userDto.UserName);
            try
            {
                operationDetails = await UserService.CreateUserAsync(userDto);
            }
            
//            catch (DbEntityValidationException dbEx)
//            {
//                Exception raise = dbEx;
//                foreach (var validationErrors in dbEx.EntityValidationErrors)
//                {
//                    foreach (var validationError in validationErrors.ValidationErrors)
//                    {
//                        string message = string.Format("{0}:{1}", 
//                            validationErrors.Entry.Entity.ToString(),
//                            validationError.ErrorMessage);
//                        // raise a new exception nesting
//                        // the current instance as InnerException
//                        raise = new InvalidOperationException(message, raise);
//                    }
//                }
//                throw raise;
//            }
            
            
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.Data);
                Console.WriteLine(e.StackTrace);
               
                return InternalServerError();
                
            }
            if (!operationDetails.Succeeded)
            {
                return BadRequest(operationDetails.Message);
            }
            return Ok(operationDetails);
        }
    }
}
