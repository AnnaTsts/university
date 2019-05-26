using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IChairService
    {
        IEnumerable<ChairDTO> GetAllChairs();

        ChairDTO GetChair(int id);

        void Insert(ChairDTO chair);
    }
}