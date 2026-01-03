using LabApi.Domain;
using LabApi.Infrastructure.Data;
using LabApi.Infrastructure.Seed;
using LabApi.Shared;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(gen =>
{
    gen.SwaggerDoc(ApiRoutes.Version1, new OpenApiInfo
    {
        Title = "Lab Api", 
        Version = ApiRoutes.Version1
    });
});

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AppDbContext>(dbContextBuilder =>
{
    dbContextBuilder.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnection"));
});


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

    using (IServiceScope scope = app.Services.CreateScope())
    {
        AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await AppDbContextSeed.SeedAsync(context);
    }
}

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.Run();