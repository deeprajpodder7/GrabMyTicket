using AngularMovieAPI2.Models.User;

namespace AngularMovieAPI2.Repository.UserRepo
{
    public interface IUserRepository
    {
        //Here we create methods that will be called in Class repository and data will be handled there.
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        Task<User> Update(User user, string password = null);
        Task<User> delete(int id);
    }
}
