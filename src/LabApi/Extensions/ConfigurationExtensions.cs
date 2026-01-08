namespace LabApi.Extensions;

public static class ConfigurationExtensions
{
    public static IConfiguration CheckAuth(this IConfiguration configuration)
    {
        var secret = configuration["Auth:Secret"];

        if (string.IsNullOrEmpty(secret))
        {
            throw new InvalidOperationException("Auth secret is not configured");
        }
        return configuration;
    }
}