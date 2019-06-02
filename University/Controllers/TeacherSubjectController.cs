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
    [RoutePrefix("api/TeacherSubject")]
    public class TeacherSubjectController: ApiController
    {
        private readonly ITeacherService _service;
        
        public TeacherSubjectController(ITeacherService serv)
        {
            _service = serv;
        }
        
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {

            IEnumerable<TeacherSubjectDTO> subject;
            try
            {
                subject = _service.GetAllSubject();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<TeacherSubjectDTO>, IEnumerable<TeacherSubjectModel>>(subject);
            return Ok(Mapper.Map<IEnumerable<TeacherSubjectDTO>, IEnumerable<TeacherSubjectModel>>(subject));
        }
        
        
        
        [Route("teacher")]
        [HttpGet]
        public IHttpActionResult GetAllTeacherSubjects()
        {
            
            IEnumerable<TeacherSubjectDTO> subject;
            try
            {
                subject = _service.GetAllSubjectByTeacher(User.Identity.GetUserId());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
                return InternalServerError(ex);
                
                
            }
            Mapper.Map<IEnumerable<TeacherSubjectDTO>, IEnumerable<TeacherSubjectModel>>(subject);
            return Ok(Mapper.Map<IEnumerable<TeacherSubjectDTO>, IEnumerable<TeacherSubjectModel>>(subject));
        }
    }
    
}