using System.Linq;
using System.Runtime.InteropServices;

namespace RomanNumerals;

public class RomanNumerals
{
    private readonly Dictionary<int, string> _romanDictionary;


    public RomanNumerals()
    {
        _romanDictionary = GetGeneralDictionary();
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


    private Dictionary<int, string> GetGeneralDictionary()
    {
        var singleLetterDictionary = GetSingleLetterDictionary();
        return singleLetterDictionary.Concat(GetCalculatedValuesDictionary(singleLetterDictionary)).DistinctBy(x => x.Key)
            .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    }

    private Dictionary<int, string> GetSingleLetterDictionary()
    {
        return new Dictionary<int, string>()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" }
        };
    }

    private Dictionary<int,string> GetCalculatedValuesDictionary(Dictionary<int, string> singleLetterDictionary)
    {
        var calculatedDictionary = new Dictionary<int, string>();
        for (int j = 1; j < 2; j++)
        {
            for (int i = 0; i < singleLetterDictionary.Count - j; i++)
            {
                var newKey = singleLetterDictionary.ElementAt(i + j).Key - singleLetterDictionary.ElementAt(i).Key;
                var newValue = singleLetterDictionary.ElementAt(i).Value + singleLetterDictionary.ElementAt(i + j).Value;
                calculatedDictionary.Add(newKey, newValue);
            }
        }

        return calculatedDictionary;
    }
}