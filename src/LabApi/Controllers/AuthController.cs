using LabApi.Application.Dtos.Register;
using LabApi.Shared;

using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers;

[ApiController]
[Route($"api/{ApiRoutes.Version1}/auth")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
    {
        throw new NotImplementedException();
    }
}