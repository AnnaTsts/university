using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DAL.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public int SpecializationId { get; set; }
        
        [ForeignKey("SpecializationId")]
        public virtual Specialization Specialization { get; set; }
        
        public virtual List<ApplicationUser> Students  {get; set; }
        
        public int FacultyId{ get; set; }
        
        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        
    }
}