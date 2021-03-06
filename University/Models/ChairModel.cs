namespace University.Models
{
    public class ChairModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int FacultyId { get; set; }

        public virtual FacultyModel Faculty { get; set; } 
    }
}