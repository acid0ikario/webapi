using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username, string password);
        Task CreateUserAsync(User user);
        Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize);
    }
}
