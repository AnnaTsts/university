using System;
using System.Collections.Generic;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class GroupRepository:IRepository<Group,int>
    {
        private ApplicationDbContext db;
        
        public GroupRepository(ApplicationDbContext context)
        {
            db = context;
        }
        
        public IEnumerable<Group> GetAll()
        {
            Console.WriteLine("Get All Group in BD");
            Console.WriteLine(db.Groups.ToList().Count);
            foreach (var g in db.Groups.ToList())
            {
                Console.WriteLine(g.Name);
            }
            return db.Groups.ToList();
        }

        public Group Get(int id)
        {
            return db.Groups.Find(id);
        }

        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return db.Groups.Where(predicate);
        }

        public void Insert(Group obj)
        {
            db.Groups.Add(obj);
        }
        

    }
}