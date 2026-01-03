using LabApi.Domain;
using LabApi.Infrastructure.Data;
using LabApi.Seed;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(dbContextBuilder =>
{
    dbContextBuilder.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
    if (builder.Environment.IsDevelopment())
    {
        dbContextBuilder.EnableDetailedErrors();
        dbContextBuilder.EnableSensitiveDataLogging();
    }
});


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await AppDbContextSeed.SeedAsync(context);
    }
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();