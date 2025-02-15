using System.Threading.Tasks;
using MyProject.Application.DTOs;
using MyProject.Application.Interfaces;
using MyProject.Domain.Entities;
using MyProject.Domain.Repositories;

namespace MyProject.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthenticationService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> AuthenticateAsync(LoginRequest request)
        {
            
            var user = _userRepository.GetUserByUsernameAsync(request.Username, request.Password);
            if (await user != null)
            {
                return _tokenService.GenerateToken(request.Username);
            }
            return null; // O lanza una excepción si la autenticación falla.
        }

        public async Task<string> CreateUserAsync(CreateUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Password = request.Password // Consider hashing the password before storing it
            };

            await _userRepository.CreateUserAsync(user);
            return _tokenService.GenerateToken(request.Username); // Optionally return a token for the new user
        }

        public async Task<List<UserDto>> GetAllUsersAsync(int pageNumber, int pageSize)
        {
            var users = await _userRepository.GetAllUsersAsync(pageNumber, pageSize);
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                Password = u.Password
                // Map other properties as needed
            }).ToList();
        }
    }
}
