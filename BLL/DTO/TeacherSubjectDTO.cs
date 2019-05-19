using System;


namespace BLL.DTO
{
    public class TeacherSubjectDTO
    {
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        
        public int SubjectId{ get; set; }
        
        public int GroupId{ get; set; }
        
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public UserDTO Teacher { get; set; }

        public GroupDTO Group { get; set; }

        public SubjectDTO Subject { get; set; }
    }
}