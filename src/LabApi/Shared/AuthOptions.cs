namespace LabApi.Shared;

public sealed class AuthOptions
{
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public string Secret { get; init; } = null!;
    public int TokenLifetimeMinutes { get; init; }
}