using DAL.Entities;

namespace BLL.DTO
{
    public class ChairDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual FacultyDTO FacultyDTO { get; set; } 
    }
}