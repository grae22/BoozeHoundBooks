namespace BoozeHoundBooks;

public partial class KTagControl : UserControl
{
    public string[] Tags
    {
        get
        {
            var tags = new List<string>();

            foreach (var item in uiTagList.CheckedItems)
            {
                tags.Add(item.ToString());
            }

            return tags.ToArray();
        }
    }

    private KTagBag _tagBag = new();

    public KTagControl()
    {
        InitializeComponent();
    }

    public void InitialiseTagBag(
        in KTagBag tagBag)
    {
        _tagBag = tagBag ?? throw new ArgumentNullException(nameof(tagBag));

        foreach (var tag in KTagBag.AllTags)
        {
            uiTagList.Items.Add(
                tag,
                _tagBag.Contains(tag));
        }
    }

    private void uiAddButton_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(uiNewTag.Text))
        {
            return;
        }

        _tagBag.Add(uiNewTag.Text);

        uiTagList.Items.Add(uiNewTag.Text, true);
    }

    private void uiNewTag_TextChanged(
        object sender,
        EventArgs e)
    {
        uiNewTag.TextChanged -= uiNewTag_TextChanged;

        uiNewTag.Text = string.Concat(
            uiNewTag
                .Text
                .Where(c => char.IsLetterOrDigit(c)));

        uiNewTag.TextChanged += uiNewTag_TextChanged;
    }
}
