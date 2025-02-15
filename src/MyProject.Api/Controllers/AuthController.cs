using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Application.Interfaces;
using MyProject.Application.DTOs;
using MyProject.Api.Attributes;

namespace MyProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthenticationService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            _logger.LogInformation("Intento de login para: {Username}", request.Username);
            
            var token = await _authService.AuthenticateAsync(request);
            if (token == null)
            {
                _logger.LogWarning("Login fallido para: {Username}", request.Username);
                return Unauthorized();
            }
            
            _logger.LogInformation("Login exitoso para: {Username}", request.Username);
            return Ok(new { token });
        }

        [HttpPost("createuser")]
        [CustomAuthorize]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            _logger.LogInformation("Intento de creación de usuario: {Username}", request.Username);

            var result = await _authService.CreateUserAsync(request);
            if (result == null)
            {
                _logger.LogWarning("Creación de usuario fallida para: {Username}", request.Username);
                return BadRequest("Error al crear el usuario.");
            }

            _logger.LogInformation("Usuario creado exitosamente: {Username}", request.Username);
            return Ok(new { message = "Usuario creado exitosamente:", request.Username, result });
        }

        [HttpGet("users")]
        [CustomAuthorize]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers(int pageNumber = 1, int pageSize = 10)
        {
            var users = await _authService.GetAllUsersAsync(pageNumber, pageSize);
            return Ok(users);
        }
    }
}
