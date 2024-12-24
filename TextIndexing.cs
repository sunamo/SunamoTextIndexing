namespace SunamoTextIndexing;
using SunamoTextIndexing.Data;

public class TextIndexing
{
    /// <summary>
    /// In key is full path to file
    /// </summary>
    public Dictionary<string, FileForSearching> files = [];

    public void ReloadFiles(List<string> list)
    {
        files.Clear();

        foreach (var item in list)
        {
            files.Add(item, new FileForSearching(item));
        }
    }
}