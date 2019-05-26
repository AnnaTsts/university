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
            IEnumerable<Group> groups = db.Groups.GetAll();
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

        public IEnumerable<GroupDTO> GetGroupByFaculty(int facultyId)
        {
            var groups = db.Groups.Find((gr) => gr.FacultyId == facultyId);
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
        }

        public IEnumerable<GroupDTO> GetGroupBySpecialization(int specialization)
        {
            var groups = db.Groups.Find((gr) => gr.SpecializationId == specialization);
            return Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(groups);
        }


    }
}