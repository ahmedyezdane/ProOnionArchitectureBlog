namespace Common.Utilities;
public static class StringExtensions
{
    public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
    {
        return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
    }

    public static int ToInt(this string value)
    {
        return Convert.ToInt32(value);
    }

    public static decimal ToDecimal(this string value)
    {
        return Convert.ToDecimal(value);
    }

    public static string ToNumeric(this int value)
    {
        return value.ToString("N0"); //"123,456"
    }

    public static string ToNumeric(this decimal value)
    {
        return value.ToString("N0");
    }

    public static string ToCurrency(this int value)
    {
        return value.ToString("C0");
    }

    public static string ToCurrency(this decimal value)
    {
        return value.ToString("C0");
    }

    public static string NullIfEmpty(this string? str)
    {
        return (str?.Length == 0 || string.IsNullOrWhiteSpace(str)) ? null : str;
    }

    public static string EmptyIfNull(this string? str)
    {
        return (str == null) ? "" : str;
    }

    public static string GetFirstNCharsOfText(this string str, int charsCount)
    {
        if (str.Length <= charsCount)
            return str;
        else
        {
            var chars = str.ToCharArray();

            string result = "";

            for (int i = 0; i < charsCount; i++)
            {
                result = result + chars[i];
            }

            return result + " ...";
        }
    }

    public static string SeoFriendlyUrl(this string str, int maxCharsCount = 80)
    {
        if (str == null)
            return "";

        return str.Trim()
                    .Replace('/', '-')
                    .Replace(' ', '-')
                    .Replace('ـ', '-')
                    .Replace('،', '-')
                    .Replace('=', '-')
                    .Replace('_', '-')
                    .GetFirstNCharsOfText(maxCharsCount);
    }
}
