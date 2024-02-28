using FileOrbis_User_Registration.Models;

namespace FileOrbis_User_Registration.Repositories
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public User Add(User newUser);
        public User Update(User updatedUser);
        public bool DeleteById(int id);

    }
}
