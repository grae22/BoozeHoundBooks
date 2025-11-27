namespace BoozeHoundBooks;

public class KTagBag
{
    public static IEnumerable<string> AllTags => _allTags;

    public IEnumerable<string> Tags => _tags;

    public int Count => _tags.Count;

    private static readonly List<string> _allTags = [];
    private static readonly Dictionary<string, decimal> _allMultipliers = [];

    private readonly List<string> _tags = [];

    public string Serialise()
    {
        return string.Join(',', _tags);
    }

    public void Deserialise(
        in string tagsCsv)
    {
        foreach (var tag in tagsCsv.Split(','))
        {
            Add(tag);
        }
    }

    public void Add(
        in string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            return;
        }

        if (_tags.Contains(tag, StringComparer.OrdinalIgnoreCase))
        {
            return;
        }

        _tags.Add(tag);
        _tags.Sort();

        if (!_allTags.Contains(tag, StringComparer.OrdinalIgnoreCase))
        {
            _allTags.Add(tag);
            _allTags.Sort();

            _allMultipliers[tag] = ExtractMultiplier(tag);
        }
    }

    public void Remove(
        in string tag)
    {
        _tags.Remove(tag);
    }

    public bool Contains(
        in string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
        {
            return false;
        }

        return _tags.Contains(tag, StringComparer.OrdinalIgnoreCase);
    }

    public decimal GetMultiplier()
    {
        foreach (var t in _tags)
        {
            decimal m = _allMultipliers[t];

            if (m != 1m)
            {
                return m;
            }
        }

        return 1m;
    }

    private static decimal ExtractMultiplier(
        in string tag)
    {
        if (!tag.Contains('/'))
        {
            return 1m;
        }

        int startIndex = tag.LastIndexOf('/') + 1;

        if (startIndex >= tag.Length)
        {
            return 1m;
        }

        string multiplierString = tag[startIndex..];

        if (decimal.TryParse(multiplierString, out decimal tagMultiplier))
        {
            tagMultiplier = 1m / tagMultiplier;
        }
        else
        {
            tagMultiplier = 1m;
        }

        return tagMultiplier;
    }
}
