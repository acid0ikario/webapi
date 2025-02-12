using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult Status()
        {
            return Ok(new { message = "El servicio está activo" });
        }
    }
}
