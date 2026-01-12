namespace LabApi.Application;

public sealed record JwtTokenResult(string Token, DateTime ExpiresAt);