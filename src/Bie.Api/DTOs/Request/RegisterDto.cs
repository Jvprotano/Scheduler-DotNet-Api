using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.DTOs.Request;
public class RegisterDto
{
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Phone Number is required")]
    public string? PhoneNumber { get; set; }
    [Required(ErrorMessage = "Birth Date is required")]
    public DateOnly BirthDate { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = string.Empty;
    [MinLength(8)]
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
    [MinLength(8)]
    [Required(ErrorMessage = "Confirm Password is required")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password must be the same")]
    public string ConfirmPassword { get; set; } = string.Empty;
}