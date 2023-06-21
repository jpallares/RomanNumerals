namespace RomanNumerals;

public class RomanNumerals
{
    private Dictionary<int, string> _romanDictionary;

    public RomanNumerals()
    {
        _romanDictionary = new Dictionary<int, string>()
        {
            {4, "IV"},
            {5, "V"},
            {10, "X"}
        };
    }
    public string Map(int arabic)
    {
        //return new string(Enumerable.Repeat('I',arabic).ToArray());

        var found = _romanDictionary.TryGetValue(arabic, out var result);

        if (!found || arabic > 5)
        {
            result = "";

            if (arabic > 5)
            {
                result = "V";
                arabic -= 5;
            }

            for (int i = 0; i < arabic; i++)
            {
                result += "I";
            }
        }

        return result;
    }
}