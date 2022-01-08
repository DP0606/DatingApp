namespace API.Entities
{
    public class AppUser
    {
      //Uvijek koristi Id jer tako će to moći pretvoriti u PK
      public int Id { get; set; }  
      public string UserName { get; set; }

      public byte[] PasswordHash { get; set; }

      public byte[] PasswordSalt { get; set; }

      //public string Conntact { get; set; }
      
    }
}