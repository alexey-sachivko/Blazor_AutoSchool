using System.ComponentModel.DataAnnotations;

namespace Blazor_AutoSchool.Shared;

public class UserRegister
{
    [Required]
    public string Surname { get; set; } = String.Empty;
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required]
    public string ThirdName { get; set; } = String.Empty;
    [Required]
    public DateTime Birthday { get; set; } = DateTime.Now.Date;
    [Required]
    public string Address { get; set; } = String.Empty;
    [Required]
    public string Role { get; set; } = "Admin";
    [Required]
    public string Passport { get; set; } = String.Empty;
    public string Contact { get; set; } = String.Empty;
    [Required]
    public string Username { get; set; } = String.Empty;
    [Required, StringLength(16, MinimumLength = 6)]
    public string Password { get; set; } = String.Empty;
}