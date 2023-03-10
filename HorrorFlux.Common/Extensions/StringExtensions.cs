namespace HorrorFlux.Common.Extensions;

public static class StringExtensions
{
    public static string Truncate(this string value, int characters)
    {
        if (string.IsNullOrWhiteSpace(value)) return string.Empty;
        if (value.Length <= characters) return value;

        return $"{value[..characters]} ...";
    }
}
