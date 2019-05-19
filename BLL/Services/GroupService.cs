using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class GroupService :IGroupService
    {
        IUnitOfWork db { get; set; }

        public GroupService(IUnitOfWork uow)
        {
            db = uow;
        }
        
        public IEnumerable<GroupDTO> GetAllGroups()
        {
            Console.WriteLine("Get All Group in service");
            IEnumerable<Group> groups = db.Groups.GetAll();
            Console.WriteLine("Get All Group from bd done ");
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
        }


        public GroupDTO GetGrop(int id)
        {
            var group = db.Groups.Get(id);
            return Mapper.Map<Group, GroupDTO>(group);
        }

        public void Insert(GroupDTO group)
        {
            db.Groups.Insert(Mapper.Map<GroupDTO, Group>(group));
            db.Save();
        }


    }
}