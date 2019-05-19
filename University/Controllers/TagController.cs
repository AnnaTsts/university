using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Textagram.Models;

namespace Textagram.Controllers
{
    [RoutePrefix("api/Tag")]
    public class TagController : ApiController
    {
        private readonly ITagService service;

        public TagController(ITagService serv)
        {
            service = serv;
        }

        // GET: api/Tag
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllTags()
        {
            IEnumerable<TagDTO> tags;
            try
            {
                tags = service.GetAllTags();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

            return Ok(Mapper.Map<IEnumerable<TagDTO>, IEnumerable<TagModel>>(tags));
        }

        // GET: api/Tag/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tag
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tag/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tag/5
        public void Delete(int id)
        {
        }
    }
}