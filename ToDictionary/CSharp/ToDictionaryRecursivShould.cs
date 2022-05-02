using Xunit;

namespace Kata.ToDictionary;

public class ToDictionaryRecursiveShould
{
    public static IEnumerable<object[]> InputDataSet()
    {
        yield return new object[] { "a=1;b=2;c=3", new[] { ("a", "1"), ("b", "2"), ("c", "3") } };
        yield return new object[] { "a=1;a=2", new[] { ("a", "2") } };
        yield return new object[] { "a=1;;b=2", new[] { ("a", "1"), ("b", "2") } };
        yield return new object[] { "a=", new[] { ("a", "") } };
        yield return new object[] { "a==1", new[] { ("a", "=1") } };
        yield return new object[] { "a = 1;;c = ;;b = = 2", new[] { ("a", "1"), ("c", ""), ("b", "=2") } };
    }

    [Theory]
    [MemberData(nameof(InputDataSet))]
    public void AnotherSplitBySemicolonAndEqualSymbol(string input, IEnumerable<(string, string)> expected)
    {
        //arrange
        var expectedDict = expected.ToDictionary(k => k.Item1, v => v.Item2);
        //act
        var result = StringParse.ToDictionary(input);
        //assert
        Assert.Equal(expectedDict, result);
    }

    [Fact]
    public void ReturnEmptyArrayOnEmptyInput()
    {
        //arrange
        var input = "";
        //act
        var result = StringParse.ToDictionary(input);
        //assert
        Assert.Equal(new Dictionary<string, string>(), result);
    }

    [Fact]
    public void ReceiveExceptionOnInvalidInput()
    {
        //arrange
        var input = "=1";
        //act
        var act = () => StringParse.ToDictionary(input);
        //assert
        Assert.Throws<ArgumentException>(act);
    }
}