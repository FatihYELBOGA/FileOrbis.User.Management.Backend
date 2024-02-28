namespace FileOrbis_User_Registration.DTO.Requests
{
    public class UserRegistrationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile Profile {  get; set; }

    }
}
