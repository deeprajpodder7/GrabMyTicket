using AngularMovieAPI2.Environment;
using AngularMovieAPI2.Helper;
using AngularMovieAPI2.Models.User;
using Microsoft.EntityFrameworkCore;


namespace AngularMovieAPI2.Repository.UserRepo
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext _context)  // Dependency Injection
        {
            context = _context;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.Password))
            {
                return null;
            }
            return user;
        }
        // VerifyPasswordHash
        private static bool VerifyPasswordHash(string password, string UserPassword)
        {
            bool checkPassword = BCrypt.Net.BCrypt.Verify(password, UserPassword);
            return checkPassword;
        }
        //Create Password Hash
        private static string CreatePasswordHash(string password)
        {
            // Bcrypting using Bcrpyt
            password = BCrypt.Net.BCrypt.HashPassword(password);
            return password;

        }

        public async Task<User> Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }
            if (await context.Users.AnyAsync(x => x.UserName == user.UserName))
            {
                throw new AppException("Username \"" + user.UserName + "\" is already taken");
            }
            user.Password = CreatePasswordHash(password);
            user.DateCreated = DateTime.UtcNow;
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> delete(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
            return user;
        }



        public async Task<User> GetById(int id)
        {

            return await context.Users.FindAsync(id);
        }

        public async Task<User> Update(User user, string password = null)
        {
            var Updateuser = await context.Users.FindAsync(user.UserID);
            if (Updateuser == null)
            {
                throw new AppException("User not found");
            }

            if (!string.IsNullOrWhiteSpace(user.UserName) && user.UserName != Updateuser.UserName)
            {
                // Throw error if the new username is already taken.
                if (await context.Users.AnyAsync(x => x.UserName == user.UserName))
                {
                    throw new AppException("Username " + user.UserName + "is already taken");

                }
                Updateuser.UserName = user.UserName;
            }
            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                Updateuser.FirstName = user.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                Updateuser.LastName = user.LastName;
            }
            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                var newPassword = CreatePasswordHash(password);
                Updateuser.Password = newPassword;
            }
            if (!string.IsNullOrWhiteSpace(user.EmailAddress))
            {
                Updateuser.EmailAddress = user.EmailAddress;

            }
            if (!string.IsNullOrWhiteSpace(user.Phone))
            {
                Updateuser.Phone = user.Phone;

            }
            context.Users.Update(Updateuser);
            await context.SaveChangesAsync();
            return Updateuser;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await context.Users.ToListAsync();
        }
    }
}
