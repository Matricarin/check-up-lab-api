using LabApi.Application.Interfaces;
using LabApi.Application.Services;

namespace LabApi.Extensions;

public static class ApiServicesExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddTransient<IClinicalTestQueryService, ClinicalTestQueryService>();
        services.AddScoped<IJwtGenerationService, JwtGenerationService>();
        return services;
    }
}