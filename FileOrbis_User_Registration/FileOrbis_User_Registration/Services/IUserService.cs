using FileOrbis_User_Registration.DTO.Requests;
using FileOrbis_User_Registration.DTO.Responses;

namespace FileOrbis_User_Registration.Services
{
    public interface IUserService
    {
        public List<UserResponse> GetAll();
        public UserResponse GetById(int id);
        public UserResponse Add(UserRegistrationRequest newUser);
        public UserResponse Update(UserUpdateRequest updatedUser, int id);
        public bool DeleteById(int id);

    }

}
