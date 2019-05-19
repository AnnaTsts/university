using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Tag
    {
        public Tag()
        {
            Books = new List<Book>();
        }

        [Key]
        [Required]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

    }
}
