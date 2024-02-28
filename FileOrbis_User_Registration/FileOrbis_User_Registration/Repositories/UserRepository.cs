using FileOrbis_User_Registration.Configurations;
using FileOrbis_User_Registration.Models;
using Microsoft.EntityFrameworkCore;

namespace FileOrbis_User_Registration.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Database database;

        public UserRepository(Database database)
        {
            this.database = database;
        }

        public List<User> GetAll()
        {
            return database.Users
                .Include(u => u.Profile)
                .ToList();
        }

        public User GetById(int id)
        {
            return database.Users
                .Where(u => u.Id == id)
                .Include(u => u.Profile)
                .FirstOrDefault();
        }

        public User Add(User newUser)
        {
            User addedUser = database.Users.Add(newUser).Entity;
            database.SaveChanges();
            return GetById(addedUser.Id);
        }

        public User Update(User updatedUser)
        {
            User returnedUser = database.Users.Update(updatedUser).Entity;
            database.SaveChanges();
            return GetById(returnedUser.Id);
        }

        public bool DeleteById(int id)
        {
            User deletedUser = GetById(id);

            if (deletedUser != null)
            {
                if (deletedUser.Profile != null)
                {
                    database.Files.Remove(deletedUser.Profile);
                }

                database.Users.Remove(deletedUser);
                database.SaveChanges();
                return true;
            } 

            return false;
        }

    }
}
