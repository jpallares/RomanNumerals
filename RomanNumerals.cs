namespace RomanNumerals;

public class RomanNumerals
{
    public static string Map(int arabic)
    {
        if (arabic == 5)
            return "V";
        if (arabic == 4)
            return "IV";
        
        string roman = "";
        while (arabic > 0)
        {
            roman += "I";
            arabic--;
        }
        
        return roman;
    }
}