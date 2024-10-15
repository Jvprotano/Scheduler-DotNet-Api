using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("cities")]
public class City : EntityBase
{
    public City(string name, string state, string country) : base()
    {
        Name = name;
        State = state;
        Country = country;
    }

    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}