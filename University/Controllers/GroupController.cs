using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using University.Models;
using Microsoft.AspNet.Identity;

namespace University.Controllers
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
        public IHttpActionResult GetAllGroups()
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

        public IHttpActionResult Post([FromBody]GroupModel model)
        {
            try
            {
                service.Insert(Mapper.Map<GroupModel,GroupDTO>(model));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
        
        [Route("Teacher")]
        [HttpGet]
        public IHttpActionResult GetAllGroupsByTeacher()
        {
            
            IEnumerable<GroupDTO> groups;
            try
            {
                groups = service.GetGroupByTeacher(User.Identity.GetUserId());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<GroupDTO>, IEnumerable<GroupModel>>(groups);
            return Ok(Mapper.Map<IEnumerable<GroupDTO>, IEnumerable<GroupModel>>(groups));
        }
        
        [HttpGet]
        public IHttpActionResult GetAllGroupsByTeacherAndSubject([FromBody]string id,int subject)
        {
            
            IEnumerable<GroupDTO> groups;
            try
            {
                groups = service.GetGroupByTeacherAndSubject(id,subject);
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