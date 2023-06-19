using Xunit;

namespace RomanNumerals;

public class RomanNumeralsTests
{
    [Theory]
    [InlineData(1, "I")]
    public void MapCorrectly(int arabic, string roman)
    {
        string result = RomanNumerals.Map(arabic);

        Assert.Equal(result, roman);
    }
}