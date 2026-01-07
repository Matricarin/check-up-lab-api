using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Shared;

using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers;

[ApiController]
[Route($"api/{ApiRoutes.Version1}/auth")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    [Produces("application/json")]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        throw new NotImplementedException();
    }

    [HttpPost("login")]
    [Produces("application/json")]
    public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto request)
    {
        throw new NotImplementedException();
    }
}