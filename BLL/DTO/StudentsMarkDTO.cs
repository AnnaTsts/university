using System;

namespace BLL.DTO
{
    public class StudentsMarkDTO
    {

        public int Id{ get; set; }
        
        public string ApplicationUserId { get; set; }

        public virtual UserDTO Student { get; set; }

        public string TeacherSubjectId { get; set; }
        
        public TeacherSubjectDTO TeacherSubject{ get; set; }
        
        public double Mark { get; set; }
        
        public string NameOfWork { get; set; }
        
        public DateTime Date{ get; set; }
        
    }
}