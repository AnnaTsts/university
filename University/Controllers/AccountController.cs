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
            IdentityOperations operationDetails;
            UserDTO userDto = new UserDTO
            {
                Email = model.Email,
                Password = model.Password,
                UserName = model.UserName
            };
            try
            {
                operationDetails = await UserService.CreateUserAsync(userDto);
            }
            catch (Exception)
            {
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
