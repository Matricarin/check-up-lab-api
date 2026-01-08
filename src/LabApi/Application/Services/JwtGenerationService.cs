using System.IdentityModel.Tokens.Jwt;

using LabApi.Application.Interfaces;
using LabApi.Domain;

namespace LabApi.Application.Services;

public sealed class JwtGenerationService : IJwtGenerationService
{
    private readonly string? _secretKey;
    private readonly string? _issuer;
    private readonly string? _audience;
    private readonly int? _expirationMinutes;
    
    public JwtGenerationService(IConfiguration configuration)
    {
        _secretKey = configuration["Auth:Secret"];
        _issuer = configuration["Auth:Issuer"];
        _audience = configuration["Auth:Audience"];
        _expirationMinutes = int.Parse(configuration["Auth:TokenLifetimeMinutes"] ?? "30");
    }

    public string GenerateJwtToken(AppUser user, IList<string> roles)
    {
        JwtSecurityTokenHandler jwtHandler = new();
        
        JwtSecurityToken token = new();

        string? jwt = jwtHandler.WriteToken(token);

        return jwt;
    }
}