using LabApi.Extensions;
using LabApi.Shared;

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

app.UseCustomSwagger();

await app.CreateDevelopmentScopes();

app.UseHttpsRedirection();
app.UseExceptionHandler();
app.MapControllers();
app.UseCors(ApiPolicy.CorsPolicyName);
app.Run();