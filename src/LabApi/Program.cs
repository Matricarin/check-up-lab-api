using LabApi.Application.Interfaces;
using LabApi.Application.Services;
using LabApi.Domain;
using LabApi.Extensions;
using LabApi.Infrastructure.Data;
using LabApi.Infrastructure.Seed;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
});

builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddApiServices();

WebApplication app = builder.Build();

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
        var roleManager = roleScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in ApiRoles.AllRoles)
        {
            if (! await roleManager.RoleExistsAsync(role))
            {
               await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.Run();