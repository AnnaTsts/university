﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        //public Dictionary<Subject, Group> SubjectWithGroup = new Dictionary<Subject, Group>();
        
        public int ChairId { get; set; }
        
    //    public virtual ChairDTO Chair { get; set; }
        
        public int GroupId  {get; set; }

      //  public virtual GroupDTO Group  {get; set; }
        
      public string FirstName { get; set; }

      public string SecondName { get; set; }
    }
}
