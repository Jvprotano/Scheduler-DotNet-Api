using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Bie.Business.ValueObjects;
[NotMapped]
public class Base64(string strValue)
{
    public string StrValue { get; } = strValue;
    public bool IsValid => IsBase64String(StrValue);

    private static bool IsBase64String(string base64)
    {
        string pattern = @"^[a-zA-Z0-9\+/]*={0,2}$";
        return (base64.Length % 4 == 0) && Regex.IsMatch(base64, pattern);
    }
}
