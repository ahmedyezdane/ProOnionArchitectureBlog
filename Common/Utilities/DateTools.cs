namespace Common.Utilities;

public static class DateTools
{
    public static DateTime DateStringToDateTime(this string dateString)
    {
        DateTime dateTime;
        bool isValidFormat = DateTime.TryParseExact(dateString, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateTime);

        if (isValidFormat)
        {
            return dateTime;
        }
        else
        {
            throw new ArgumentException("Invalid date string format. Expected format: yyyy-MM-dd");
        }
    }
}
