namespace Textagram.Models
{
    public class GroupModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual FacultyModel FacultyModel { get; set; } 
    }
}