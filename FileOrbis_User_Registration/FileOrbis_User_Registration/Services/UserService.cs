using FileOrbis_User_Registration.DTO.Requests;
using FileOrbis_User_Registration.DTO.Responses;
using FileOrbis_User_Registration.Models;
using FileOrbis_User_Registration.Repositories;
using System.Text;

namespace FileOrbis_User_Registration.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserResponse> GetAll()
        {
            List<UserResponse> userResponses = new List<UserResponse>();
            foreach (var user in userRepository.GetAll())
            {
                userResponses.Add(new UserResponse(user));
            }
            return userResponses;
        }

        public UserResponse GetById(int id)
        {
            return new UserResponse(userRepository.GetById(id));
        }

        public UserResponse Add(UserRegistrationRequest newUser)
        {
            User user = new User();

            Models.File profile = null;
            if (newUser.Profile != null)
            {
                if (newUser.Profile.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        newUser.Profile.CopyTo(stream);
                        var bytes = stream.ToArray();

                        profile = new Models.File()
                        {
                            Name = newUser.Profile.FileName,
                            Type = newUser.Profile.ContentType,
                            Content = bytes
                        };
                    }
                }
            }
            user.Profile = profile;

            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.Email = newUser.Email;
            user.Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(newUser.Password));

            return new UserResponse(userRepository.Add(user));
        }

        public UserResponse Update(UserUpdateRequest updatedUser, int id)
        {
            User user = userRepository.GetById(id);
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;

            return new UserResponse(userRepository.Update(user));
        }

        public bool DeleteById(int id)
        {
            return userRepository.DeleteById(id);
        }

    }
}
