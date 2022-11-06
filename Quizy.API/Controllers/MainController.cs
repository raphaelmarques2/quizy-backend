using Microsoft.AspNetCore.Mvc;

namespace Quizy.API.Controllers
{
    [ApiController]
    [Route("")]
    public class MainController : ControllerBase
    {
        
        private readonly ILogger<MainController> _logger;

        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public ActionResult<string> Get()
        {
            return Ok("Ok");
        }
    }
}