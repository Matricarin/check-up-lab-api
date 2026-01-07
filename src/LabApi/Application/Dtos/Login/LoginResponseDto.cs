namespace LabApi.Application.Dtos.Login;

public sealed record LoginResponseDto
{
    public string AccessToken { get; init; } = null!;
    public DateTime ExpiresAt { get; init; }
}