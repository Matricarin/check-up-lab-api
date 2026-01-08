using LabApi.Shared;

namespace LabApi.Extensions;

public static class CorsServicesExtensions
{
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(ApiCorsPolicy.CorsPolicyName, policy =>
            {
                policy.WithOrigins("https://localhost:5137")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return services;
    }
}