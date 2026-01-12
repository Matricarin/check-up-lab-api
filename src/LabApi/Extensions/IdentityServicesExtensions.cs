using LabApi.Domain;
using LabApi.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Extensions;

public static class IdentityServicesExtensions
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireDigit = true;
            opt.Lockout.MaxFailedAccessAttempts = 3;
            opt.Lockout.AllowedForNewUsers = true;
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        });

        return services;
    }

    public static IServiceCollection AddIdentityStorage(this IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
        return services;
    }
}