using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupDTO> GetAllGroups();

        GroupDTO GetGrop(int id);
        
        void Insert(GroupDTO group);
        IEnumerable<GroupDTO> GetGroupByFaculty(int facultyId);

        IEnumerable<GroupDTO> GetGroupBySpecialization(int specialization);
        
        
    }
}