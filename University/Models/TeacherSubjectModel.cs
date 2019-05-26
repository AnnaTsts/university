using System;


namespace University.Models
{
    public class TeacherSubjectModel
    {
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        
        public int SubjectId{ get; set; }
        
        public int GroupId{ get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public UserModel Teacher { get; set; }

        public GroupModel Group { get; set; }

        public SubjectModel Subject { get; set; }
    }
}