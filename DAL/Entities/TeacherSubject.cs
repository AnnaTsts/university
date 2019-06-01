using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class TeacherSubject
    {
        [Key]
        public int Id { get; set; }
        
        
        [Column(Order = 2)]
        public string TeacherId { get; set; }
        

        [Column(Order = 3)]
        public int SubjectId{ get; set; }
        

        [Column(Order = 4)]
        public int GroupId{ get; set; }
        
        
        [ForeignKey("TeacherId")]
        public virtual ApplicationUser Teacher { get; set; }
        
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }
        
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }

    }
}