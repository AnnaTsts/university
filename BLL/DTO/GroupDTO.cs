using System.Collections.Generic;

namespace BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int SpecializationId { get; set; }
        
        public virtual SpecializationDTO Specialization { get; set; }
        
        public virtual List<UserDTO> Students  {get; set; }
        
        public int FacultyId{ get; set; }
        
        public virtual FacultyDTO Faculty { get; set; }
    }
}