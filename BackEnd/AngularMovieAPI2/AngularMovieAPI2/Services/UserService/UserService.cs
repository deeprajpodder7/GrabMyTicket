using AngularMovieAPI2.Models.User;
using AngularMovieAPI2.Repository.UserRepo;

namespace AngularMovieAPI2.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;

        public UserService(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        public async Task<User> Authenticate(string username, string password) => await userRepo.Authenticate(username, password);


        public async Task<User> Create(User user, string password) => await userRepo.Create(user, password);

        public async Task<User> delete(int id) => await userRepo.delete(id);


        public async Task<IEnumerable<User>> GetAllUsers() => await userRepo.GetAllUsers();

        public async Task<User> GetById(int id) => await userRepo.GetById(id);


        public async Task<User> Update(User user, string password = null) => await userRepo.Update(user, password);

    }
}
