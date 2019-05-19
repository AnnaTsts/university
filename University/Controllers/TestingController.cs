using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.Services;
using DAL.Repositories;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace Textagram.Controllers
{
    
    public class TestingController : ApiController
    {
        private readonly IBookService service;
        public TestingController(IBookService serv)
        {
            service = serv;
        }
        // GET api/<controller>
        public IEnumerable<BookDTO> Get()
        {
            //GetBookInfoService service = new GetBookInfoService(new UnitOfWork());
            return service.GetAllBooks();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //public UserDTO Get(int id)
        //{

        //    //GetBookInfoService service = new GetBookInfoService(new UnitOfWork());
        //    //return service.GetBook(id);
        //    //GetUserInfoService service = new GetUserInfoService(new UnitOfWork());
        //    return service.GetUser(id);
        //}

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}