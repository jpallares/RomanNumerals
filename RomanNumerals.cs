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
            {50, "L"}
        };
        _concreteNumbersDictionary = new Dictionary<int, string>()
        {
            //{ 16, "XVI" }
        };
    }
    public string Map(int arabic)
    {
        //return new string(Enumerable.Repeat('I',arabic).ToArray());
        var mergedDictionaries = _romanDictionary.Concat(_concreteNumbersDictionary)
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        var found = mergedDictionaries.TryGetValue(arabic, out var result);

        if (!found)
        {
            result = "";
            var previousEntry = _romanDictionary.Last(x => x.Key < arabic);
            (arabic,result) = GetResultIfIsOneLessThanRomanNumber(arabic, result);


            if (arabic > 0)
            {
                result += previousEntry.Value;
                arabic -= previousEntry.Key;

                if (_romanDictionary.ContainsKey(arabic))
                {
                    result += _romanDictionary[arabic];
                }

                else
                {
                    (arabic,result) = GetResultIfIsOneLessThanRomanNumber(arabic, result);
                    if (arabic > 0)
                    {
                        for (int i = 0; i < arabic; i++)
                        {
                            result += "I";
                        }
                    }

                }

            }

        }

        return result;
    }

    private Tuple<int,string> GetResultIfIsOneLessThanRomanNumber(int arabic, string result)
    {
        var entryWhereIsOneMoreThanArabic = _romanDictionary.SingleOrDefault(x => x.Key == arabic + 1);
        if (entryWhereIsOneMoreThanArabic.Key != default)
        {
            result += string.Concat("I" + entryWhereIsOneMoreThanArabic.Value);
        }

        arabic -= entryWhereIsOneMoreThanArabic.Key;
        return new Tuple<int, string>(arabic,result);
    }

}