namespace BLL.DTO
{
    public class SummaryInfo
    {
        
        public string Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public int ChairId { get; set; }

        public int GroupId  {get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
        
        public string ChairName { get; set; }
        
        public string GroupName { get; set; }
        
        public string FacultyName { get; set; }
        
        public string SpecializationName { get; set; }
    }
}