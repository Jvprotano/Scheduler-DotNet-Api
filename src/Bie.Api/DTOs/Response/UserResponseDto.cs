using Bie.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Response;
public class UserResponseDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Phone { get; set; }
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth Date is required")]
    public DateOnly BirthDate { get; set; }
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
}