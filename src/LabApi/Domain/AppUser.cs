using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace LabApi.Domain;

public sealed class AppUser : IdentityUser
{
    [StringLength(maximumLength: 50, 
        ErrorMessage = "Display name should be from 1 to 50 symbols", 
        MinimumLength = 1)]
    public required string DisplayName { get; set; }
}