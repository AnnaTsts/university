using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using University.Models;

namespace University.Controllers
{
    [RoutePrefix("api/Subject")]
    public class SubjectController: ApiController
    {
        private readonly IUserService _service_user;
        private readonly ISubjectService _service;
       
        
        public SubjectController(ISubjectService serv,IUserService serv_user)
        {
            _service = serv;
            _service_user = serv_user;
        }
        
        
        public IHttpActionResult GetAllSubjects()
        {
            IEnumerable<SubjectDTO> subjects;
            try
            {
                subjects = _service.GetAllSubjects();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<SubjectDTO>, IEnumerable<SubjectModel>>(subjects);
            return Ok(Mapper.Map<IEnumerable<SubjectDTO>, IEnumerable<SubjectModel>>(subjects));
        }
        
        public IHttpActionResult GetAllSubjectsByStudent()
        {
            IEnumerable<SubjectDTO> subjects;
            try
            {
                subjects = _service.GetAllSubjects();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<SubjectDTO>, IEnumerable<SubjectModel>>(subjects);
            return Ok(Mapper.Map<IEnumerable<SubjectDTO>, IEnumerable<SubjectModel>>(subjects));
        }
    }
    
    
}