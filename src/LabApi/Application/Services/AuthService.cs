using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Domain;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IJwtGenerationService jwtGenerationService;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<AppUser> userManager;

    public AuthService(UserManager<AppUser> userManager, 
        RoleManager<IdentityRole> roleManager,
        IJwtGenerationService jwtGenerationService)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        this.jwtGenerationService = jwtGenerationService;
    }

    public Task<RegisterResponseDto> CreateUser(RegisterRequestDto request)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResponseDto> LoginUser(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }
}