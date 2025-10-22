using Agende.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Agende.Api.DTOs.Response;
public class UserResponseDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth Date is required")]
    public DateOnly BirthDate { get; set; }
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Display(Name = "Image")]
    public string ImageUrl { get; set; } = string.Empty;
}