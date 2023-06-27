using Moq;
using Xunit;

namespace RomanNumerals;

public class RomanNumeralsTests
{
    private readonly RomanDictionaryProvider dictionaryProvider;

    public RomanNumeralsTests()
    {
        dictionaryProvider = new RomanDictionaryProvider();
    }

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
    [InlineData(11, "XI")]
    [InlineData(12, "XII")]
    [InlineData(13, "XIII")]
    [InlineData(14, "XIV")]
    [InlineData(15, "XV")]
    [InlineData(16, "XVI")]
    [InlineData(300, "CCC")]
    [InlineData(400, "CD")]
    [InlineData(95, "XCV")]
    [InlineData(3000, "MMM")]
    [InlineData(1652, "MDCLII")]
    public void MapCorrectly(int arabic, string roman)
    {
        string result = new RomanNumerals(dictionaryProvider).Map(arabic);

        Assert.Equal(result, roman);
    }
}