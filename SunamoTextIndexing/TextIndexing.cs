// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoTextIndexing;

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