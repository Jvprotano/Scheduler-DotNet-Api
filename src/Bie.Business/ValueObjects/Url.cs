using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Bie.Business.ValueObjects;
[NotMapped]
public class Url : IValueObject
{
    public Url(string address)
    {
        Address = address;
    }

    public string Address { get; }
    public bool IsValid => IsValidUrl(Address);

    private static bool IsValidUrl(string url)
    {
        string pattern = @"^(https?:\/\/)?([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}(\/[a-zA-Z0-9-._~:?#@!$&'()*+,;=]*)?$";
        return !string.IsNullOrEmpty(url) && Regex.IsMatch(url, pattern);
    }
}
