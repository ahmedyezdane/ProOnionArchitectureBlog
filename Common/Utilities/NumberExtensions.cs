namespace Common.Utilities;
public static class NumberExtensions
{
    public static int? TryCast(this string input)
    {
        return RegexTools.IsOnlyNumberDigits(input) ? int.Parse(input) : null;
    }

    public static int[] StringToIntArray(this string aggregetedNumbers, char seprator)
    {
        var sepreratedStrings = aggregetedNumbers.Split(seprator);

        int[] result = new int[sepreratedStrings.Length];

        for (int i = 0; i < result.Length; i++)
        {
            if (RegexTools.IsOnlyNumberDigits(sepreratedStrings[i]))
                result[i] = int.Parse(sepreratedStrings[i]);
        }

        return result;
    }

    public static int RoundNumber(this int number,int roundBy = 10)
    {
        int remaining = number % roundBy;
        return remaining >= 5 ? (number - remaining + 10) : (number - remaining);
    }
}

