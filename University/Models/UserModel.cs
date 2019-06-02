namespace University.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }
        
        //public Dictionary<Subject, Group> SubjectWithGroup = new Dictionary<Subject, Group>();
        
      //  public int ChairId { get; set; }
        
       // public virtual Chair Chair { get; set; }
        
      //  public int GroupId  {get; set; }
      public int ChairId { get; set; }
        
    //  public virtual ChairModel Chair { get; set; }
        
      public int GroupId  {get; set; }

     // public virtual GroupModel Group  {get; set; }
    }
}