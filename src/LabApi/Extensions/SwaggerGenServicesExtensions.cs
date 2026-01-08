using LabApi.Shared;

using Microsoft.OpenApi.Models;

namespace LabApi.Extensions;

public static class SwaggerGenServicesExtensions
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        OpenApiSecurityScheme securityScheme = new()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Ведите токен:"
        };
        services.AddSwaggerGen(gen =>
        {
            gen.AddSecurityDefinition("Bearer", securityScheme);
            gen.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, []} });

            gen.SwaggerDoc(ApiRoutes.Version1, new OpenApiInfo { Title = "Lab Api", Version = ApiRoutes.Version1 });
        });

        return services;
    }
}