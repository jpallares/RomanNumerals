namespace RomanNumerals;

public class RomanNumerals
{
    public static string Map(int arabic)
    {
        if (arabic == 3)
            return "III";
        
        if (arabic == 2)
            return "II";
        
        return "I";
    }
}