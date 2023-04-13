using AngularMovieAPI2.Models.User;

namespace AngularMovieAPI2.Services.UserService
{
    public interface IUserService
    {
        public Task<User> Authenticate(string username, string password);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> GetById(int id);
        public Task<User> Create(User user, string password);
        public Task<User> Update(User user, string password = null);
        public Task<User> delete(int id);
    }
}
