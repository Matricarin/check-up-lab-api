using LabApi.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Extensions;

public static class DbContextServicesExtensions
{
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(context => 
            context.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));
        return services;
    }
}