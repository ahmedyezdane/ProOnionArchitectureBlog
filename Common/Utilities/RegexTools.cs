using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Common.Utilities;

public static class RegexTools
{
    public static bool IsOnlyNumberDigits(this string str)
    {
        var rgx = new Regex("^\\d+$");

        return rgx.IsMatch(str);
    }

    public static bool IsValidEmail(this string email)
    {
        var rgx = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");

        return rgx.IsMatch(email);
    }

    public static bool IsValidDateString(this string date)
    {
        // yyyy-MM-dd
        var rgx = new Regex(@"^\d{4}-\d{2}-\d{2}$");

        if(!rgx.IsMatch(date))
            return false;

        if (!DateTime.TryParse(date, out DateTime date1))
            return false;

        return true;
    }
}
