using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class StudentsMark
    {
        [Key]
        public int Id{ get; set; }
        
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser Student { get; set; }

        public int TeacherSubjectId { get; set; }
        
        [ForeignKey("TeacherSubjectId")]
        public TeacherSubject TeacherSubject{ get; set; }

        [Required]
        public double Mark { get; set; }
        
        public string NameOfWork { get; set; }
        
        public DateTime Date{ get; set; }

    }
}