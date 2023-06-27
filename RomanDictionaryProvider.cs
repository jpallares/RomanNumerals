namespace RomanNumerals;


public interface IRomanDictionaryProvider
{
    Dictionary<int, string> GetRomanDictionary();
}
public class RomanDictionaryProvider : IRomanDictionaryProvider
{
    private readonly Dictionary<int, string> _singleLetterDictionary;
    private readonly Dictionary<int, string> _calculatedDictionary;
    private readonly Dictionary<int, string> _romanDictionary;

    public RomanDictionaryProvider()
    {
        _singleLetterDictionary = GetSingleLetterDictionary();
        _calculatedDictionary = GetCalculatedValuesDictionary();
        _romanDictionary = GenerateRomanDictionary();
    }

    public Dictionary<int, string> GetRomanDictionary()
    {
        return _romanDictionary;
    }

    private Dictionary<int, string> GenerateRomanDictionary()
    {
        return _singleLetterDictionary.Concat(_calculatedDictionary).DistinctBy(x => x.Key)
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

    private Dictionary<int,string> GetCalculatedValuesDictionary()
    {
        var calculatedDictionary = new Dictionary<int, string>();

        AddFirstThreeNumbers(calculatedDictionary);

        AddMissingCombinations(calculatedDictionary);

        return calculatedDictionary;
    }

    private void AddFirstThreeNumbers(Dictionary<int, string> calculatedDictionary)
    {
        for (int i = 1; i <= 3; i++)
        {
            calculatedDictionary.Add(i, string.Concat(Enumerable.Repeat('I', i)));
        }
    }

    private void AddMissingCombinations(Dictionary<int, string> calculatedDictionary)
    {
        for (int j = 1; j <= 2; j++)
        {
            for (int i = 0; i < _singleLetterDictionary.Count - j; i++)
            {
                var newKey = _singleLetterDictionary.ElementAt(i + j).Key - _singleLetterDictionary.ElementAt(i).Key;
                var newValue = _singleLetterDictionary.ElementAt(i).Value + _singleLetterDictionary.ElementAt(i + j).Value;
                calculatedDictionary.Add(newKey, newValue);
            }
        }
    }
}