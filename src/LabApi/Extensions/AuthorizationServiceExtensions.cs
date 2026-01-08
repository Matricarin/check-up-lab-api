using LabApi.Shared;

namespace LabApi.Extensions;

public static class AuthorizationServiceExtensions
{
    public static IServiceCollection AddAuthorizationService(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(ApiPermissions.ClinicalTestsRead, policy => policy.RequireAuthenticatedUser());
        });

        return services;
    }
}