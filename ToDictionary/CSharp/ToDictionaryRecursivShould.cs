using Xunit;

namespace Kata.ToDictionary;

public class ToDictionaryRecursiveShould
{
    public static IEnumerable<object[]> InputDataSet()
    {
        yield return new object[] { "a=1;b=2;c=3", new []{("a", "1"), ("b", "2"), ("c", "3") } };
        yield return new object[] { "a=1;b=2", new []{("a", "1"), ("b", "2")} };
        yield return new object[] { "a=1;;b=2", new []{("a", "1"), ("b", "2")} };
        yield return new object[] { "a=", new []{("a", "")} };
        yield return new object[] { "a==1", new []{("a", "=1")} };
    }

    [Theory]
    [MemberData(nameof(InputDataSet))]
    public void AnotherSplitBySemicolonAndEqualSymbol(string input, IEnumerable<(string, string)> expected)
    {
        //act
        var result = input.ToDictionaryRecursive();
        //assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReturnEmptyArrayOnEmptyInput()
    {
        //arrange
        var input = "";
        //act
        var result = input.ToDictionaryRecursive();
        //assert
        Assert.Equal(Enumerable.Empty<(string, string)>(), result);
    }

    [Fact]
    public void ReceiveExceptionOnInvalidInput()
    {
        //arrange
        var input = "=1";
        //act
        var act = () => input.ToDictionaryRecursive();
        //assert
        Assert.Throws<ArgumentException>(act);
    }
}