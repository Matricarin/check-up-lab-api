using LabApi.Infrastructure.Data;
using LabApi.Infrastructure.Seed;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Extensions;

public static class WebApplicationExtensions
{
    public static async Task<WebApplication> CreateDevelopmentScopes(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            using (IServiceScope seedingScope = webApplication.Services.CreateScope())
            {
                AppDbContext context = seedingScope.ServiceProvider.GetRequiredService<AppDbContext>();
                await AppDbContextSeed.SeedAsync(context);
            }

            using (IServiceScope roleScope = webApplication.Services.CreateScope())
            {
                RoleManager<IdentityRole> roleManager =
                    roleScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                foreach (string role in ApiRoles.AllRoles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }

        return webApplication;
    }

    public static WebApplication UseCustomSwagger(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment() || webApplication.Environment.IsStaging())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
            webApplication.MapOpenApi();
        }

        return webApplication;
    }
}