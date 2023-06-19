namespace RomanNumerals;

public class RomanNumerals
{
    public static string Map(int arabic)
    {
        string roman = "";

        while (arabic > 0)
        {
            roman += "I";
            arabic--;
        }
        
        return roman;
    }
}