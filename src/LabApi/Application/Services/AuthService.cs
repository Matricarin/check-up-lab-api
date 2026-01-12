using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;
using LabApi.Application.Interfaces;
using LabApi.Domain;
using LabApi.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IJwtGenerationService _jwtGenerationService;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _db;
    public AuthService(UserManager<AppUser> userManager, 
        RoleManager<IdentityRole> roleManager,
        AppDbContext db,
        IJwtGenerationService jwtGenerationService)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._db = db;
        this._jwtGenerationService = jwtGenerationService;
    }

    public async Task<RegisterResponseDto?> CreateUser(RegisterRequestDto request)
    {
        var appUser = new AppUser()
        {
            DisplayName = request.DisplayName,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(appUser, request.Password);

        if (!result.Succeeded)
        {
            //  TODO: return errors
        }

        throw new NotImplementedException();
    }

    public async Task<LoginResponseDto?> LoginUser(LoginRequestDto request)
    {
        throw new NotImplementedException();
    }
}