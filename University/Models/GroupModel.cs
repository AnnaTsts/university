using System.Collections.Generic;

namespace University.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual FacultyModel Faculty { get; set; } 
        
        public int SpecializationId { get; set; }
        
        public virtual SpecializationModel Specialization { get; set; }
        
          public virtual List<UserModel> Students  {get; set; }
    }
}