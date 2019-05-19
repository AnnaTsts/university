using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public int SpecializationId { get; set; }
        
        [ForeignKey("SpecializationId")]
        public Specialization Specialization { get; set; }
        
        public virtual List<ApplicationUser> Students  {get; set; }
        
        public int FacultyId{ get; set; }
        
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        
    }
}