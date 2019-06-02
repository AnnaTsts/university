using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {


        public string FirstName { get; set; }


        public string SecondName { get; set; }
        
        public string ImgSrc { get; set; }

        public int ChairId { get; set; }
        
     //   [ForeignKey("ChairId")]
     //   public virtual Chair Chair { get; set; }
        

        public int GroupId  {get; set; }
        
   //    [ForeignKey("GroupId")]
     //  public virtual Group Group  {get; set; }
        
        //public virtual List<StudentsMark> StudentsMarks  {get; set; }

        //public virtual List<S>
    }
}
