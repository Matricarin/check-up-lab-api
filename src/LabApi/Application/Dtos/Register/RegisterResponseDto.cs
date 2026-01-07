namespace LabApi.Application.Dtos.Register;

public sealed record RegisterResponseDto
{
    public string AccessToken { get; init; } = null!;
    public DateTime ExpiresAt { get; init; }
}