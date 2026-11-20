namespace SunamoTextIndexing.Data;

/// <summary>
/// File for searching.
/// </summary>
/// <param name="path">The path.</param>
/// <returns>The file for searching result.</returns>
public class FileForSearching(string path)
{
    /// <summary>
    /// Gets or sets the is surely no.
    /// </summary>
    public bool IsSurelyNo { get; set; }

    /// <summary>
    /// Gets or sets the found lines.
    /// </summary>
    public List<int> FoundLines { get; set; } = [];

    /// <summary>
    /// Gets or sets the lowercase lines.
    /// </summary>
    public List<string> LowercaseLines { get; set; } = [];

    /// <summary>
    /// Gets or sets the lines.
    /// </summary>
    public List<string> Lines { get; set; } = [];

    /// <summary>
    /// Init.
    /// </summary>
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
