using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Identity;

namespace DAL.Entities
{
    public class Book
    {
        public Book()
        {
            Tags = new List<Tag>();
            Marks = new List<Mark>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<Tag> Tags { get; set; }

        public virtual List<Mark> Marks { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
