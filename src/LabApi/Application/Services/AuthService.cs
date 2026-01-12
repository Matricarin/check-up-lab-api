using System.Security.Claims;

using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Domain;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IJwtGenerationService _jwtGenerationService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<AppUser> signInManager,
        IJwtGenerationService jwtGenerationService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _jwtGenerationService = jwtGenerationService;
    }

    public async Task<RegisterResponseDto?> CreateUser(RegisterRequestDto request)
    {
        AppUser appUser = new() { DisplayName = request.DisplayName, UserName = request.Email, Email = request.Email };

        IdentityResult result = await _userManager.CreateAsync(appUser, request.Password);

        if (!result.Succeeded)
        {
            //  TODO: add logging
            return null;
        }

        await _userManager.AddToRoleAsync(appUser, ApiRoles.DefaultRole);
        await _userManager.AddClaimsAsync(appUser,
            ApiPermissions.DefaultPermissions.Select(p => new Claim(ApiPermissions.PermissionClaimType, p)));

        string token = _jwtGenerationService.GenerateJwtToken(appUser, new List<string> { ApiRoles.DefaultRole },
            ApiPermissions.DefaultPermissions.ToList());

        RegisterResponseDto
            response = new() { AccessToken = token, ExpiresAt =  }; //  TODO: in appsettings i am written earlier

        return response;
    }

    public async Task<LoginResponseDto?> LoginUser(LoginRequestDto request)
    {
        AppUser? user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return null;
        }

        SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

        if (!result.Succeeded)
        {
            return null;
        }

        IList<string> role = await _userManager.GetRolesAsync(user);
        IList<Claim> claims = await _userManager.GetClaimsAsync(user);

        List<string> permissions = claims.Where(c => c.Type == ApiPermissions.PermissionClaimType)
            .Select(c => c.Value)
            .ToList();

        string token = _jwtGenerationService.GenerateJwtToken(user, role, permissions);

        LoginResponseDto
            response = new() { AccessToken = token, ExpiresAt =  }; //  TODO: in appsettings i am written earlier

        return response;
    }
}