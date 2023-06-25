using System.Runtime.InteropServices;

namespace RomanNumerals;

public class RomanNumerals
{
    private Dictionary<int, string> _romanDictionary;
    private Dictionary<int, string> _concreteNumbersDictionary;

    public RomanNumerals()
    {
        _romanDictionary = new Dictionary<int, string>()
        {
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
        };
    }
    public string Map(int arabic)
    {
        var result = "";
        while (arabic > 0)
        {
            var found = _romanDictionary.TryGetValue(arabic, out var foundResult);

            if (found)
            {
                arabic  = 0;
                result += foundResult;
            }

            else
            {
                var previousEntry = _romanDictionary.Last(x => x.Key < arabic);
                (arabic, result) = GetResultIfIsOneLessThanRomanNumber(arabic, result);

                if (arabic <= 0)
                    continue;

                result += previousEntry.Value;
                arabic -= previousEntry.Key;

                if (arabic <= 3)
                {
                    result += string.Concat(Enumerable.Repeat('I', arabic));
                    arabic = 0;
                }
            }
        }

        return result;
    }

    private Tuple<int,string> GetResultIfIsOneLessThanRomanNumber(int arabic, string result)
    {
        if (arabic == 9)
            return new Tuple<int, string>(0, result+="IX");

        var previousEntry = _romanDictionary.Last(x => x.Key < arabic);
        var entryWhereIsOneMoreThanArabic = _romanDictionary.SingleOrDefault(x => x.Key == arabic + previousEntry.Key);
        if (entryWhereIsOneMoreThanArabic.Key != default)
        {
            result += string.Concat(previousEntry.Value + entryWhereIsOneMoreThanArabic.Value);
        }

        arabic -= entryWhereIsOneMoreThanArabic.Key;
        return new Tuple<int, string>(arabic,result);
    }

}