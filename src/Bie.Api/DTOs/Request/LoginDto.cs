using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Request;
public class LoginDto
{
    [Required(ErrorMessage = "Field email or phone is required")]
    [Display(Name = "E-mail or Phone")]
    public string EmailOrPhone { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    public bool RememberMe { get; set; }
}