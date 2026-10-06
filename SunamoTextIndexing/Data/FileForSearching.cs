namespace SunamoTextIndexing.Data;

public class FileForSearching(string path)
{
    public bool IsSurelyNo { get; set; }

    public List<int> FoundLines { get; set; } = [];

    public List<string> LowercaseLines { get; set; } = [];

    public List<string> Lines { get; set; } = [];

    public async Task Init()
    {
        Lines = [.. (await FileAsync.ReadAllLinesAsync(path))];
        LowercaseLines = new List<string>(Lines.Count);
        foreach (var item in Lines)
        {
            LowercaseLines.Add(item.ToLower());
        }
    }
}
