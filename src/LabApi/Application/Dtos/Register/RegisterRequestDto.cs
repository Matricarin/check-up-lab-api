using System.ComponentModel.DataAnnotations;

namespace LabApi.Application.Dtos.Register;

public sealed record RegisterRequestDto
{
    [Required] [Compare(nameof(Password))] public string ConfirmPassword { get; init; } = null!;

    [Required] public string DisplayName { get; init; } = null!;

    [Required] [EmailAddress] public string Email { get; init; } = null!;

    [Required] [MinLength(8)] public string Password { get; init; } = null!;
}