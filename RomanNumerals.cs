using System.Linq;
using System.Runtime.InteropServices;

namespace RomanNumerals;

public class RomanNumerals
{
    private readonly IRomanDictionaryProvider _dictionaryProvider;

    public RomanNumerals(IRomanDictionaryProvider dictionaryProvider)
    {
        _dictionaryProvider = dictionaryProvider;
    }

    public string Map(int arabic)
    {
        var result = "";
        var dictionary = _dictionaryProvider.GetRomanDictionary();
        while (arabic > 0)
        {
            var found = dictionary.TryGetValue(arabic, out var foundResult);

            if (found)
            {
                arabic  = 0;
                result += foundResult;
            }

            else
            {
                var previousEntry = dictionary.Last(x => x.Key < arabic);

                result += previousEntry.Value;
                arabic -= previousEntry.Key;

            }
        }

        return result;
    }
}