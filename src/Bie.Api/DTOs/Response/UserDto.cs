using Bie.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Response;
public class UserResponseDto : BaseDto
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth Date is required")]
    public DateTime BirthDate { get; set; }
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    // [Display(Name = "Password")]
    // [DataType(DataType.Password)]
    // [MinLength(8)]
    // [Required(ErrorMessage = "Password is required")]
    // public string? Password { get; set; }
    // [Display(Name = "Confirm Password")]
    // [DataType(DataType.Password)]
    // [MinLength(8)]
    // [Required(ErrorMessage = "Confirm Password is required")]
    // public string? ConfirmPassword { get; set; }
}