using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Agende.Business.Enums;

namespace Agende.Business.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
    }

    public ApplicationUser(
        string firstName,
        string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public DateOnly? BirthDate { get; set; }
    public string? CPF { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Active;
    public string? ImageUrl { get; set; }
    [NotMapped]
    public string? ImageBase64 { get; set; }

    public IList<Scheduling>? Schedulings { get; set; }
    public IList<CompanyEmployee>? UserCompanies { get; set; }
    public List<EmployeeServiceLink>? Services { get; set; }

    [NotMapped]
    public IList<Company>? Companies { get; set; }
}