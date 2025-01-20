using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/exceptionController")]
    public class ExceptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Middleware olmadan result döndürüldü.");
        }
    }
}