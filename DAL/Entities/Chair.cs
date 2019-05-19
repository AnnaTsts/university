using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Chair
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        
    }
}