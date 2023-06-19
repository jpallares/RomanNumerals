namespace RomanNumerals;

public class RomanNumerals
{
    private readonly Dictionary<int, string> _equivalencies = new()
    {
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public string Map(int arabic)
    {
        string roman = "";
        
        foreach (var (keyArabic, valueRoman) in _equivalencies)
        {
            while (arabic >= keyArabic)
            {
                roman += valueRoman;
                arabic -= keyArabic;
            }
        }
        
        return roman;
    }
}