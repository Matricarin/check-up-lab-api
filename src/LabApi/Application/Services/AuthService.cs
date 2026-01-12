using System.Security.Claims;

using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Domain;
using LabApi.Infrastructure.Data;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly AppDbContext _db;
    private readonly IJwtGenerationService _jwtGenerationService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        AppDbContext db,
        IJwtGenerationService jwtGenerationService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _db = db;
        _jwtGenerationService = jwtGenerationService;
    }

    public async Task<RegisterResponseDto?> CreateUser(RegisterRequestDto request)
    {
        AppUser appUser = new() 
        { 
            DisplayName = request.DisplayName, 
            UserName = request.Email,
            Email = request.Email
        };

        IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

        if (!result.Succeeded)
        {
            //  TODO: add logging
            return null;
        }

        await _userManager.AddToRoleAsync(appUser, ApiRoles.DefaultRole);
        await _userManager.AddClaimsAsync(appUser,
            ApiPermissions.DefaultPermissions.Select(p => new Claim(ApiPermissions.PermissionClaimType, p)));

        string token = _jwtGenerationService.GenerateJwtToken(appUser, new List<string> { ApiRoles.Consumer },
            new List<string> { ApiPermissions.ClinicalTestsRead });

        RegisterResponseDto response = new() { AccessToken = token, ExpiresAt =  };

        return response;
    }

    public async Task<LoginResponseDto?> LoginUser(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }
}