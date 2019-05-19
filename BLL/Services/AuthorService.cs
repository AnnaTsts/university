using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Repositories;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;


namespace BLL.Services
{
    public class AuthorService : IAuthorService
    {
        IUnitOfWork db { get; set; }

        public AuthorService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<BookDTO> GetAllBooks(int id)
        {
            var books = db.Books.GetAll();
            return Mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
        }
    }
}
