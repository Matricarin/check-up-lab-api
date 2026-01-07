using System.ComponentModel.DataAnnotations;

namespace LabApi.Application.Dtos.Login;

public sealed record LoginRequestDto
{
    [Required] [EmailAddress] public string Email { get; init; } = null!;

    [Required] [MinLength(8)] public string Password { get; init; } = null!;
}