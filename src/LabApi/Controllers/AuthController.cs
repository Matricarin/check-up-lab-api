using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Shared;

using Microsoft.AspNetCore.Authorization;
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
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
    {
        LoginResponseDto? response = await _authService.LoginUser(request);

        if (response == null)
        {
            return Unauthorized();
        }

        return Ok(response);
    }

    [HttpPost("register")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(RegisterResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [AllowAnonymous]
    public async Task<ActionResult<RegisterResponseDto>> Register([FromBody] RegisterRequestDto request)
    {
        RegisterResponseDto? response = await _authService.CreateUser(request);

        if (response == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Register), response);
    }
}