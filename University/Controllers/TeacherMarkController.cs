using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using University.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace University.Controllers
{
    [RoutePrefix("api/TeacherMark")]
    public class TeacherMarkController : ApiController
    {
        private readonly IStudentsMarkService _service;
        
        public TeacherMarkController(IStudentsMarkService serv)
        {
            _service = serv;
        }
        
        public IHttpActionResult GetAllMarks()
        {
            IEnumerable<StudentsMarkDTO> marks;
            try
            {
                marks = _service.GetAllMarks();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<StudentsMarkDTO>, IEnumerable<StudentsMarksModel>>(marks);
            return Ok(Mapper.Map<IEnumerable<StudentsMarkDTO>, IEnumerable<StudentsMarksModel>>(marks));
        }

        public IHttpActionResult Post([FromBody]StudentsMarksModel model)
        {
            model.TeacherSubject.TeacherId= User.Identity.GetUserId();
             
            try
            {
                _service.Insert(Mapper.Map<StudentsMarksModel,StudentsMarkDTO>(model));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
        
        public IHttpActionResult PostAll([FromBody]List<StudentsMarksModel> models)
        {
            foreach (var model in models)
            {
                model.TeacherSubject.TeacherId= User.Identity.GetUserId();
            }
            
            try
            {
                foreach (var model in models)
                {
                    _service.Insert(Mapper.Map<StudentsMarksModel,StudentsMarkDTO>(model));
                }
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
        
        
    }
}