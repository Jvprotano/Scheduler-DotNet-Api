using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Request;
public class LoginDto
{
    [Required(ErrorMessage = "Field email or username is required")]
    [Display(Name = "E-mail or User Name")]
    public string? EmailOrUserName { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public bool RememberMe { get; set; }
}