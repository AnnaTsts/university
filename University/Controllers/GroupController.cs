using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Textagram.Models;

namespace Textagram.Controllers
{
    
    [RoutePrefix("api/Group")]
    public class GroupController : ApiController
    {
        private readonly IGroupService service;
        
        public GroupController(IGroupService serv)
        {
            service = serv;
        }
        
        [HttpGet]
        public IHttpActionResult GetAllBooks()
        {
            Console.WriteLine("Get All Group");
            IEnumerable<GroupDTO> groups;
            try
            {
                groups = service.GetAllGroups();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            Mapper.Map<IEnumerable<GroupDTO>, IEnumerable<GroupModel>>(groups);
            return Ok(Mapper.Map<IEnumerable<GroupDTO>, IEnumerable<GroupModel>>(groups));
        }
    }
}