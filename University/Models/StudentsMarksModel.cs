using System;


namespace University.Models
{
    public class StudentsMarksModel
    {
        public int Id{ get; set; }
        
        public string ApplicationUserId { get; set; }

        public virtual UserModel Student { get; set; }

        public string TeacherSubjectId { get; set; }
        
        public TeacherSubjectModel TeacherSubject{ get; set; }
        
        public double Mark { get; set; }
        
        public string NameOfWork { get; set; }
        
        public DateTime Date{ get; set; }
    }
}