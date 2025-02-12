using System.Threading.Tasks;
using MyProject.Application.DTOs;
using MyProject.Application.Interfaces;
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
            if (request.Username == "admin" && request.Password == "password")
            {
                // Si en el futuro agregas alguna llamada asíncrona, podrás awaitearla aquí
                return _tokenService.GenerateToken(request.Username);
            }
            return null; // O lanza una excepción si la autenticación falla.
        }
    }
}
