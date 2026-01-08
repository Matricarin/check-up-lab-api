using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using LabApi.Application.Interfaces;
using LabApi.Domain;
using LabApi.Shared;

using Microsoft.IdentityModel.Tokens;

namespace LabApi.Application.Services;

public sealed class JwtGenerationService : IJwtGenerationService
{
    private readonly string? _audience;
    private readonly int? _expirationMinutes;
    private readonly string? _issuer;
    private readonly string? _secretKey;

    public JwtGenerationService(IConfiguration configuration)
    {
        _secretKey = configuration["Auth:Secret"];
        _issuer = configuration["Auth:Issuer"];
        _audience = configuration["Auth:Audience"];
        _expirationMinutes = int.Parse(configuration["Auth:TokenLifetimeMinutes"] ?? "30");
    }

    public string GenerateJwtToken(AppUser user, IList<string> roles, IList<string> permissions)
    {
        JwtSecurityTokenHandler jwtHandler = new();

        byte[] key = Encoding.UTF8.GetBytes(_secretKey ??
                                            throw new InvalidOperationException("Jwt secret is not configured"));

        List<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.Name, user.UserName!)
        ];

        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
        claims.AddRange(permissions.Select(permission => new Claim(ApiPermissions.PermissionClaimType, permission)));


        SecurityTokenDescriptor descriptor = new()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes((double)_expirationMinutes!),
            Issuer = _issuer,
            Audience = _audience,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken? token = jwtHandler.CreateToken(descriptor);

        string? jwt = jwtHandler.WriteToken(token);

        return jwt;
    }
}