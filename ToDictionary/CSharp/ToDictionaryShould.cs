using Xunit;

namespace Kata.ToDictionary;

public class ToDictionaryShould
{
    public static IEnumerable<object[]> InputDataSet()
    {
        yield return new object[] { "a=1;b=2;c=3", new Dictionary<string, string> { ["a"] = "1", ["b"] = "2", ["c"] = "3" } };
        yield return new object[] { "a=1;a=2", new Dictionary<string, string> { ["a"] = "2" } };
        yield return new object[] { "a=1;;b=2", new Dictionary<string, string> { ["a"] = "1", ["b"] = "2" } };
        yield return new object[] { "a=", new Dictionary<string, string> { ["a"] = "" } };
        yield return new object[] { "a==1", new Dictionary<string, string> { ["a"] = "=1" } };
        yield return new object[] { "a = 1;;c = ;;b = = 2", new Dictionary<string, string> { ["a"] = "1", ["c"] = "", ["b"] = "=2" } };//end game
    }

    [Theory]
    [MemberData(nameof(InputDataSet))]
    public void SplitBySemicolonAndEqualSymbol(string input, Dictionary<string, string> expected)
    {
        //act
        var result = ToDictionaryExtension.ToDictionary(input);
        //assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReturnEmptyArrayOnEmptyInput()
    {
        //arrange
        var input = "";
        //act
        var result = ToDictionaryExtension.ToDictionary(input);
        //assert
        Assert.Equal(new Dictionary<string, string>(), result);
    }

    [Fact]
    public void ReceiveExceptionOnInvalidInput()
    {
        //arrange
        var input = "=1";
        //act
        var act = () => ToDictionaryExtension.ToDictionary(input);
        //assert
        Assert.Throws<ArgumentException>(act);
    }
}