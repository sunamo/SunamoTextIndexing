namespace SunamoTextIndexing;

public class TextIndexing
{
    public Dictionary<string, FileForSearching> Files { get; set; } = [];

    public void ReloadFiles(List<string> list)
    {
        Files.Clear();
        foreach (var item in list)
        {
            Files.Add(item, new FileForSearching(item));
        }
    }
}
