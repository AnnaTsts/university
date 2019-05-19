using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Mark
    {
        [Required]
        public int Value { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Key]
        [Column(Order = 2)]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
