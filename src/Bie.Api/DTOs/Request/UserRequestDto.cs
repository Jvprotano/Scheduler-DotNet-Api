using Bie.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Request;
public class UserRequestDto : BaseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth Date is required")]
    public DateOnly BirthDate { get; set; }
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Display(Name = "Phone")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = string.Empty;
    [Display(Name = "Image")]
    public string ImageBase64 { get; set; } = string.Empty;
}