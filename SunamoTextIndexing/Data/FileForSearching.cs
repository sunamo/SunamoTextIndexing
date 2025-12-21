namespace SunamoTextIndexing.Data;

public class FileForSearching(string path)
{
    public bool surelyNo = false;
    public List<int> foundedLines = [];
    public List<string> linesLower = [];
    public List<string> lines = [];

    public async Task Init()
    {
        lines = [.. (await File.ReadAllLinesAsync(path))];
        linesLower = new List<string>(lines.Count);
        foreach (var item in lines)
        {
            linesLower.Add(item.ToLower());
        }
    }
}