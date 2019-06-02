using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using University.Models;

namespace Textagram.Controllers
{
    [RoutePrefix("api/Chair")]
    public class ChairController: ApiController
    {
        private readonly IChairService service;
        
        public ChairController(IChairService serv)
        {
            service = serv;
        }
        
        [HttpGet]
        public IHttpActionResult GetAllchairs()
        {
           
            IEnumerable<ChairDTO> chairs;
            try
            {
                chairs = service.GetAllChairs();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
                
            }
            Mapper.Map<IEnumerable<ChairDTO>, IEnumerable<ChairModel>>(chairs);
            return Ok(Mapper.Map<IEnumerable<ChairDTO>, IEnumerable<ChairModel>>(chairs));
        }

        public IHttpActionResult Post([FromBody]ChairModel model)
        {
            try
            {
                service.Insert(Mapper.Map<ChairModel,ChairDTO>(model));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
    
}