namespace Kata.ToDictionary;

public static class ToDictionaryExtension
{
    public static IEnumerable<(string, string)> ToDictionary(this string input)
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
                        : new[] { (inner.First(), inner.Last()) };
                }
            );
        return innerSplit.ToList();
    }

    public static IEnumerable<(string, string)> ToDictionaryRecursive(this string input) =>
        ToDict( input.Split(';', StringSplitOptions.RemoveEmptyEntries));

    private static IEnumerable<(string, string)> ToDict(IEnumerable<string> list)
    {
        var value = list as string[] ?? list.ToArray();
        if (!value.Any()) return Enumerable.Empty<(string, string)>();
        var head = value.FirstOrDefault();
        var tail = value.Skip(1);
        return head!.Split('=') switch
        {
            { Length: 2 } l => string.IsNullOrWhiteSpace(l[0])
                ? throw new ArgumentException()
                : new[] { (l.First(), l.Last()) }.Concat(ToDict(tail)),

            { Length: 3 } l => new[] { (l.First(), $"={l.Last()}") }.Concat(ToDict(tail)),

            _ => Enumerable.Empty<(string, string)>()
        };
    }
}