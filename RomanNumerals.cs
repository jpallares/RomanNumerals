namespace RomanNumerals;

public class RomanNumerals
{
    private readonly Dictionary<int, string> _equivalencies = new()
    {
        { 1000, "M" }, 
        { 900, "CM" }, 
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
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