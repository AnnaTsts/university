using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupDTO> GetAllGroups();

        GroupDTO GetGrop(int id);
        
        void Insert(GroupDTO group);
        

    }
}