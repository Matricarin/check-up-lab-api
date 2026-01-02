using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabApi.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LabBaseController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SayHello()
        {
            return Ok("Hello world");
        }
    }
}
