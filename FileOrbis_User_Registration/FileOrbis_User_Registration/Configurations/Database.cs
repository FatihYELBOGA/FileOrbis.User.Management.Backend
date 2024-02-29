using FileOrbis_User_Registration.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FileOrbis_User_Registration.Configurations
{
    public class Database : DbContext
    {
        public Database(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Models.File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user-file tables relationships on the profile
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(f => f.User)
                .HasForeignKey<User>(u => u.ProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        private static User[] users = new User[]
        {
            /*
            new User 
            { 
                FirstName = "Fatih",
                LastName = "YELBOĞA",
                Email = "fatihyelboga@gmail.com",
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("fatih123"))
            },
            new User
            {
                FirstName = "Osman",
                LastName = "ALTUNAY",
                Email = "osmanaltunay@gmail.com",
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes("osman123"))
            }
            */
        };

        public static void Seed(Database database)
        {
            if (database.Database.GetPendingMigrations().Count() == 0)
            {
                if (database.Users.Count() == 0)
                {
                    database.Users.AddRange(users);
                    database.SaveChanges();
                }
            }
        }

    }
}
