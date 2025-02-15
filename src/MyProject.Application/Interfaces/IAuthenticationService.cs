using System.Threading.Tasks;
using MyProject.Application.DTOs;

namespace MyProject.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> AuthenticateAsync(LoginRequest request);
        Task<string> CreateUserAsync(CreateUserRequest request);
        Task<List<UserDto>> GetAllUsersAsync(int pageNumber, int pageSize);
    }
}
