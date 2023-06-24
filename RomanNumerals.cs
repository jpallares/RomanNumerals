﻿namespace RomanNumerals;

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
            { 4, "IV" },
            { 9, "IX" },
            { 14, "XIV" }
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
            for (int i = 0; i < _romanDictionary.Count; i++)
            {
                if (arabic > _romanDictionary.Keys.ElementAt(i) && arabic < _romanDictionary.Keys.ElementAt(i + 1))
                {
                    result = _romanDictionary.Values.ElementAt(i);
                    arabic -= _romanDictionary.Keys.ElementAt(i);
                    break;
                }
                
            }

            for (int i = 0; i < arabic; i++)
            {
                result += "I";
            }
        }

        return result;
    }
}