namespace SunamoTextIndexing;

/// <summary>
/// Manages a collection of files indexed for fast text searching.
/// </summary>
public class TextIndexing
{
    /// <summary>
    /// Dictionary where the key is the full path to a file and the value is its search data.
    /// </summary>
    public Dictionary<string, FileForSearching> Files { get; set; } = [];

    /// <summary>
    /// Clears the current file index and reloads it with the specified file paths.
    /// </summary>
    /// <param name="list">List of full file paths to index for searching.</param>
    public void ReloadFiles(List<string> list)
    {
        Files.Clear();
        foreach (var item in list)
        {
            Files.Add(item, new FileForSearching(item));
        }
    }
}
