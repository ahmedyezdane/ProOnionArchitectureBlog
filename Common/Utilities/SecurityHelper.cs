using System.Security.Cryptography;
using System.Text;

namespace Common.Utilities;
public static class SecurityHelper
{
    // Used for Encoding the password with sha256 Algorithm
    public static string GetSha256Hash(this string input)
    {
        using (var sha256 = SHA256.Create())
        {
            var byteValue = Encoding.UTF8.GetBytes(input);
            var byteHash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
    }
}
