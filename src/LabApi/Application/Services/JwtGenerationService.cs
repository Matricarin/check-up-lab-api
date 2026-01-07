using LabApi.Application.Interfaces;
using LabApi.Domain;

namespace LabApi.Application.Services;

public sealed class JwtGenerationService : IJwtGenerationService
{
    private readonly string? _secretKey;

    public JwtGenerationService(IConfiguration configuration)
    {
        _secretKey = configuration["AuthConfiguration:Secret"];
    }

    public string GenerateJwtToken(AppUser user, IList<string> roles)
    {
        throw new NotImplementedException();
    }
}