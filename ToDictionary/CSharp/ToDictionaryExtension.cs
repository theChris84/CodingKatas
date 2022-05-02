namespace Kata.ToDictionary;

public static class StringParse
{
    public static IDictionary<string, string> ToDictionary(this string input) =>
        AsDictionary(input.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .Reverse()
            .ToDictionary(k => k.key, v => v.value);

    private static IEnumerable<(string key, string value)> AsDictionary(IEnumerable<string> list)
    {
        var value = list as string[] ?? list.ToArray();
        if (!value.Any()) return Enumerable.Empty<(string, string)>();

        var head = value.First();
        var tail = value.Skip(1);

        return head.Split('=', StringSplitOptions.TrimEntries) switch
        {
            { Length: 2 } arr => string.IsNullOrWhiteSpace(arr[0])
                ? throw new ArgumentException()
                : AsDictionary(tail).Union(new[] { (arr.First(), arr.Last()) }, new CompareKeyValuePair()),

            { Length: 3 } arr => AsDictionary(tail)
                .Union(new[] { (arr.First(), $"={arr.Last()}") }, new CompareKeyValuePair()),

            _ => Enumerable.Empty<(string, string)>()
        };
    }
    private record CompareKeyValuePair : IEqualityComparer<(string, string)>
    {
        public bool Equals((string, string) x, (string, string) y) => x.Item1 == y.Item1;

        public int GetHashCode((string, string) obj) => HashCode.Combine(obj.Item1);
    }
}


public static class ToDictionaryExtension
{
    public static Dictionary<string, string> ToDictionary(this string input)
    {
        var listSplit = input.Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (!listSplit.Any()) return new Dictionary<string, string>();
        var innerSplit = listSplit
            .Select(i => i.Split('=', 2, StringSplitOptions.TrimEntries))
            .GroupBy(kvp => kvp.First())
            .SelectMany(group =>
                {
                    var kvp = group.Last();
                    if (kvp[0] == "")
                        throw new ArgumentException();

                    return new[] { ( kvp.First(), kvp.Last().Replace(" ", ""))};
                }
            );
        return innerSplit.ToDictionary(k => k.Item1, v => v.Item2);
    }
}