using FileOrbis_User_Registration.Models;

namespace FileOrbis_User_Registration.DTO.Responses
{
    public class UserResponse
    {
        public UserResponse(User user) 
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;

            if(user.Profile != null)
            {
                Profile = new FileResponse(user.Profile);
            }
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public FileResponse Profile { get; set; }

    }

}
