using LabApi.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Extensions;

public static class DbContextServicesExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var cs = configuration.GetConnectionString("Postgres");

        if (string.IsNullOrWhiteSpace(cs))
        {
            throw new InvalidOperationException("Postgres connection string is not configured");
        }

        services.AddDbContext<AppDbContext>(context => 
            context.UseNpgsql(configuration.GetConnectionString("Postgres")));
        return services;
    }
}