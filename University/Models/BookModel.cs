using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Textagram.Models
{
    public class BookModel
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public string ApplicationUserId { get; set; }

        public string UserName { get; set; }

        public List<TagModel> Tags { get; set; }

        //public virtual TagModel[] Tags { get; set; }

        public double? Mark { get; set; }

        public int? Id { get; set; }
    }
}