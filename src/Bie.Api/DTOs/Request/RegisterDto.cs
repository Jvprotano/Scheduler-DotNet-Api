using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Request;
public class RegisterDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Phone { get; set; }
    [Required(ErrorMessage = "Birth Date is required")]
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    [MinLength(8)]
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
    [MinLength(8)]
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password must be the same")]
    public string? ConfirmPassword { get; set; }
}