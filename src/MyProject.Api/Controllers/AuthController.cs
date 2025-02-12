using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyProject.Application.Interfaces;
using MyProject.Application.DTOs;

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
    }
}
