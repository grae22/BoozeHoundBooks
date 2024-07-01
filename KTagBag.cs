namespace BoozeHoundBooks;

public class KTagBag
{
    public static IEnumerable<string> AllTags => _allTags;

    public IEnumerable<string> Tags => _tags;

    public int Count => _tags.Count;

    private static readonly List<string> _allTags = new();

    private readonly List<string> _tags = new();

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
}
