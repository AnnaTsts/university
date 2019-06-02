using System;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;

namespace Textagram.Controllers
{
    [RoutePrefix("api/Summary")]
    public class SummaryController: ApiController
    {
        private readonly IUserService _service;
       
        
        public SummaryController(IUserService serv)
        {
            _service = serv;
        }
          
        
        [HttpGet]
        public IHttpActionResult GetSummary()
        {
            SummaryInfo summaryInfo = new SummaryInfo();
            try
            {
                
                summaryInfo.Id = User.Identity.GetUserId();
                summaryInfo.UserName = User.Identity.GetUserName();
                _service.GetSumm(summaryInfo,User.Identity.GetUserName());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            
            return Ok(summaryInfo);
        }
        
        
    }
    
    
}