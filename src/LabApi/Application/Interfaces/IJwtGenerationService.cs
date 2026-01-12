using LabApi.Domain;

namespace LabApi.Application.Interfaces;

public interface IJwtGenerationService
{
    JwtTokenResult GenerateJwtToken(AppUser user, IList<string> roles, IList<string> permissions);
}