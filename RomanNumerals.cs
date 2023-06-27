using System.Runtime.InteropServices;

namespace RomanNumerals;

public class RomanNumerals
{
    private readonly Dictionary<int, string> _romanDictionary;
    private readonly Dictionary<int, string> _calculatedDictionary;
    private readonly Dictionary<int, string> _fullDictionary;


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
        _calculatedDictionary = new Dictionary<int, string>();
        for (int i = 0; i < _romanDictionary.Count - 2; i++)
        {
            var newKey = _romanDictionary.ElementAt(i + 2).Key - _romanDictionary.ElementAt(i).Key;
            var newValue = _romanDictionary.ElementAt(i).Value + _romanDictionary.ElementAt(i + 2).Value;
            _calculatedDictionary.Add(newKey, newValue);
        }
        for (int i = 0; i < _romanDictionary.Count - 1; i++)
        {
            var newKey = _romanDictionary.ElementAt(i + 1).Key - _romanDictionary.ElementAt(i).Key;
            var newValue = _romanDictionary.ElementAt(i).Value + _romanDictionary.ElementAt(i + 1).Value;
            _calculatedDictionary.Add(newKey, newValue);
        }

        _fullDictionary = _romanDictionary.Concat(_calculatedDictionary).DistinctBy(x => x.Key).OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
    }

    public string Map(int arabic)
    {
        var result = "";
        while (arabic > 0)
        {
            var found = _fullDictionary.TryGetValue(arabic, out var foundResult);

            if (found)
            {
                arabic  = 0;
                result += foundResult;
            }

            else
            {
                var previousEntry = _fullDictionary.Last(x => x.Key < arabic);

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

}