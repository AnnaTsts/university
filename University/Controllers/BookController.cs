using AutoMapper;
using BLL.DTO;
using BLL.Services;
using BLL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Repositories;
using Textagram.Models;

namespace Textagram.Controllers
{
    [Authorize]
    [RoutePrefix("api/Book")]
    public class BookController : ApiController
    {
        private readonly IBookService service;

        public BookController(IBookService serv)
        {
            service = serv;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllBooks()
        {
            IEnumerable<BookDTO> books;
            try
            {
                books = service.GetAllBooks();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            Mapper.Map<IEnumerable<BookDTO>, IEnumerable<BookModel>>(books);
            return Ok(Mapper.Map<IEnumerable<BookDTO>, IEnumerable<BookModel>>(books));
        }
        
        // POST: api/Book
        [Route("")]
        public IHttpActionResult Post([FromBody]BookModel book)
        {
            try
            {
                service.Insert(Mapper.Map<BookModel,BookDTO>(book));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            return Ok();
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
