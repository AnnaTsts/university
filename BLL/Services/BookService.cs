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
    public class BookService : IBookService
    {
        IUnitOfWork db { get; set; }

        public BookService(IUnitOfWork uow)
        {
            db = uow;
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            IEnumerable<Book> books = db.Books.GetAll();
            foreach(Book b in books)
            {
                double mark = 0;
                foreach(Mark m in b.Marks)
                {
                    mark += m.Value;
                }
                mark /= b.Marks.Count;
            }
            return  Mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(books);
        }

        public BookDTO GetBook(int id)
        {
            var book = db.Books.Get(id);
            return Mapper.Map<Book, BookDTO>(book);
        }

        public void Insert(BookDTO book)
        {
            db.Books.Insert(Mapper.Map<BookDTO, Book>(book));
            db.Save();
        }
    }
}
