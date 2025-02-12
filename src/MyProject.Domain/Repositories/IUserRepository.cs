using System.Threading.Tasks;
using MyProject.Domain.Entities;

namespace MyProject.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        // Aquí puedes agregar otros métodos, como CreateUserAsync, UpdateUser, etc.
    }
}
