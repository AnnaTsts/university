using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class MarkDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }

        public int Value { get; set; }

    }
}
