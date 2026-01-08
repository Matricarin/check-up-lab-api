using LabApi.Shared;

namespace LabApi.Extensions;

public static class AuthenticationServiceExtensions
{
    public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
    {
        
        return services;
    }

    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<AuthOptions>(configuration.GetSection("Auth"));
        return services;
    }
}