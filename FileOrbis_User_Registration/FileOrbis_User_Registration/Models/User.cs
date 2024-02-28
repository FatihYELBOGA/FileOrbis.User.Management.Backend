namespace FileOrbis_User_Registration.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ProfileId { get; set; }
        public File? Profile { get; set; }

    }

}
