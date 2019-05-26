using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using University.Models;
using System.Web.Http;

namespace University.Controllers
{
    [RoutePrefix("api/Marks")]
    public class TeacherMarkController : ApiController
    {
        private readonly IStudentsMarkService service;
        
        public TeacherMarkController(IStudentsMarkService serv)
        {
            service = serv;
        }
        
        public IHttpActionResult GetAllMarks()
        {
            IEnumerable<StudentsMarkDTO> marks;
            try
            {
                marks = service.GetAllMarks();
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
            try
            {
                service.Insert(Mapper.Map<StudentsMarksModel,StudentsMarkDTO>(model));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
}