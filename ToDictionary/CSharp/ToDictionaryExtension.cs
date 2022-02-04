namespace Kata.ToDictionary;

public static class ToDictionaryExtension
{
    public static IList<(string, string)> ToDictionary(this string input)
    {
        var listSplit = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
        if (!listSplit.Any()) return Array.Empty<(string, string)>();
        var innerSplit = listSplit
            .Select(i => i.Split('=', 2))
            .SelectMany(inner =>
                {
                    if (inner[0] == "")
                        throw new ArgumentException();

                    return !inner.Any()
                        ? Array.Empty<(string, string)>()
                        : new[] { (inner[0], inner[1]) };
                }
            );
        return innerSplit.ToList();
    }
}