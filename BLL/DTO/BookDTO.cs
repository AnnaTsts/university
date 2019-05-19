using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            Tags = new List<TagDTO>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string UserName { get; set; }

        public string ApplicationUserId { get; set; }
        
        public virtual List<TagDTO> Tags { get; set; }

        public double Mark { get; set; }
        
        
    }
}
