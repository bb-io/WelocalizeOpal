namespace Apps.Opal.Extensions;

public static class StringExtensions
{
    public static bool Matches(this string source, string? match)
    { 
        return string.IsNullOrWhiteSpace(match) || source.Contains(match, StringComparison.OrdinalIgnoreCase);
    }
}