using System.Security.Claims;

using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Shared;

using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers;

[ApiController]
[Route($"api/{ApiRoutes.Version1}/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto? request)
    {
        //  TODO: update controller
        if (request == null)
        {
            return BadRequest();
        }

        var response = await _authService.LoginUser(request);
        return SignIn(new ClaimsPrincipal());
    }

    [HttpPost("register")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RegisterResponseDto), StatusCodes.Status201Created)]
    public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto? request)
    {
        //  TODO: update controller
        if (request == null)
        {
            return BadRequest();
        }
        var response = await _authService.CreateUser(request);
        return Created("register", response);
    }
}