using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}