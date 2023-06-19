namespace RomanNumerals;

public class RomanNumerals
{
    private readonly (int, string)[] _equivalencies =
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };

    public string Map(int arabic)
    {
        var roman = "";
        
        foreach (var (arabicEquivalency, romanEquivalency) in _equivalencies)
        {
            while (arabic >= arabicEquivalency)
            {
                roman += romanEquivalency;
                arabic -= arabicEquivalency;
            }
        }
        
        return roman;
    }
}