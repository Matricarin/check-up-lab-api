using LabApi.Extensions;
using LabApi.Infrastructure.Data;
using LabApi.Infrastructure.Seed;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddIdentityConfiguration();
builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddIdentityStorage();
builder.Services.AddApiServices();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

    using (IServiceScope seedingScope = app.Services.CreateScope())
    {
        AppDbContext context = seedingScope.ServiceProvider.GetRequiredService<AppDbContext>();
        await AppDbContextSeed.SeedAsync(context);
    }

    using (IServiceScope roleScope = app.Services.CreateScope())
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

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.UseCors(ApiPolicy.CorsPolicyName);
app.Run();