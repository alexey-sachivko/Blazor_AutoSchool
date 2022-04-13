using System.ComponentModel.DataAnnotations;

namespace Blazor_AutoSchool.Shared;

public class UserLogin
{
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}