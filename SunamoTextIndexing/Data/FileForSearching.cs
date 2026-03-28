namespace SunamoTextIndexing.Data;

/// <summary>
/// Represents a file loaded for text searching with lowercase indexing support.
/// </summary>
/// <param name="path">Full path to the file to be loaded for searching.</param>
public class FileForSearching(string path)
{
    /// <summary>
    /// Indicates whether this file is certainly not a match for the current search.
    /// </summary>
    public bool IsSurelyNo { get; set; }

    /// <summary>
    /// Line numbers where search matches were found.
    /// </summary>
    public List<int> FoundLines { get; set; } = [];

    /// <summary>
    /// All lines from the file converted to lowercase for case-insensitive searching.
    /// </summary>
    public List<string> LowercaseLines { get; set; } = [];

    /// <summary>
    /// All original lines from the file.
    /// </summary>
    public List<string> Lines { get; set; } = [];

    /// <summary>
    /// Reads the file from disk and initializes both original and lowercase line collections.
    /// </summary>
    public async Task Init()
    {
        Lines = [.. (await File.ReadAllLinesAsync(path))];
        LowercaseLines = new List<string>(Lines.Count);
        foreach (var item in Lines)
        {
            LowercaseLines.Add(item.ToLower());
        }
    }
}
