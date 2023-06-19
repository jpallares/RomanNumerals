using Xunit;

namespace RomanNumerals;

public class RomanNumeralsTests
{
    [Theory]
    [InlineData(1, "I")]
    [InlineData(2, "II")]
    [InlineData(3, "III")]
    [InlineData(4, "IV")]
    [InlineData(5, "V")]
    public void MapCorrectly(int arabic, string expectedRoman)
    {
        string result = RomanNumerals.Map(arabic);

        Assert.Equal(expectedRoman, result);
    }
}