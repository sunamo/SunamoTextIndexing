namespace SunamoTextIndexing;

/// <summary>
/// Represents the text indexing type.
/// </summary>
public class TextIndexing
{
    /// <summary>
    /// Gets or sets the files.
    /// </summary>
    public Dictionary<string, FileForSearching> Files { get; set; } = [];

    /// <summary>
    /// Reload files.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The reload files result.</returns>
    public void ReloadFiles(List<string> list)
    {
        Files.Clear();
        foreach (var item in list)
        {
            Files.Add(item, new FileForSearching(item));
        }
    }
}
