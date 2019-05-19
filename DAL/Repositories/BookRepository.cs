using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository : IRepository<Book, int>
    {
        private ApplicationDbContext db;

        public BookRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate);
        }

        public Book Get(int id)
        { 
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books.ToList();
        }

        public void Insert(Book obj)
        {
            db.Books.Add(obj);
        }
    }
}
