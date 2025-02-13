using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.Api.Attributes;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new { message = "El servicio está activo " });
        }

        [HttpGet("userinfo")]
        [CustomAuthorize]
        public IActionResult GetUserInfo()
        {
            // Obtener los claims del usuario (token)
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

            // Obtener todos los headers de la solicitud
            var headers = Request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString());

            // Información básica de la solicitud
            var requestInfo = new {
                Method = Request.Method,
                Path = Request.Path,
                QueryString = Request.QueryString.ToString()
            };

            // Retornar todos los datos disponibles
            return Ok(new {
                UserName = User.Identity.Name,
                IsAuthenticated = User.Identity.IsAuthenticated,
                Claims = claims,
                Headers = headers,
                RequestInfo = requestInfo
            });
        }
    }
}
