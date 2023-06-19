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
    [InlineData(6, "VI")]
    [InlineData(7, "VII")]
    [InlineData(8, "VIII")]
    [InlineData(9, "IX")]
    [InlineData(10, "X")]
    [InlineData(17, "XVII")]
    [InlineData(38, "XXXVIII")]
    [InlineData(479, "CDLXXIX")]
    [InlineData(3999, "MMMCMXCIX")]
    public void MapCorrectly(int arabic, string expectedRoman)
    {
        string result = new RomanNumerals().Map(arabic);

        Assert.Equal(expectedRoman, result);
    }
}