using SunamoTextIndexing.Data;

namespace SunamoTextIndexing.Tests;

/// <summary>
/// Unit tests for the TextIndexing and FileForSearching classes.
/// </summary>
public class UnitTest1
{
    /// <summary>
    /// Verifies that ReloadFiles populates the Files dictionary with correct keys.
    /// </summary>
    [Fact]
    public void ReloadFiles_WithFilePaths_PopulatesDictionary()
    {
        var textIndexing = new TextIndexing();
        var filePaths = new List<string> { "file1.txt", "file2.txt", "file3.txt" };

        textIndexing.ReloadFiles(filePaths);

        Assert.Equal(3, textIndexing.Files.Count);
        Assert.True(textIndexing.Files.ContainsKey("file1.txt"));
        Assert.True(textIndexing.Files.ContainsKey("file2.txt"));
        Assert.True(textIndexing.Files.ContainsKey("file3.txt"));
    }

    /// <summary>
    /// Verifies that ReloadFiles clears existing entries before adding new ones.
    /// </summary>
    [Fact]
    public void ReloadFiles_CalledTwice_ClearsPreviousEntries()
    {
        var textIndexing = new TextIndexing();
        var firstFilePaths = new List<string> { "old1.txt", "old2.txt" };
        var secondFilePaths = new List<string> { "new1.txt" };

        textIndexing.ReloadFiles(firstFilePaths);
        textIndexing.ReloadFiles(secondFilePaths);

        Assert.Single(textIndexing.Files);
        Assert.True(textIndexing.Files.ContainsKey("new1.txt"));
        Assert.False(textIndexing.Files.ContainsKey("old1.txt"));
    }

    /// <summary>
    /// Verifies that FileForSearching initializes with default property values.
    /// </summary>
    [Fact]
    public void FileForSearching_NewInstance_HasDefaultValues()
    {
        var fileForSearching = new FileForSearching("test.txt");

        Assert.False(fileForSearching.IsSurelyNo);
        Assert.Empty(fileForSearching.FoundLines);
        Assert.Empty(fileForSearching.LowercaseLines);
        Assert.Empty(fileForSearching.Lines);
    }

    /// <summary>
    /// Verifies that Init reads the file and populates both Lines and LowercaseLines.
    /// </summary>
    [Fact]
    public async Task Init_WithExistingFile_PopulatesLinesAndLowercaseLines()
    {
        var tempFilePath = Path.GetTempFileName();
        try
        {
            await File.WriteAllLinesAsync(tempFilePath, new[] { "Hello World", "TEST Line", "MiXeD CaSe" });
            var fileForSearching = new FileForSearching(tempFilePath);

            await fileForSearching.Init();

            Assert.Equal(3, fileForSearching.Lines.Count);
            Assert.Equal("Hello World", fileForSearching.Lines[0]);
            Assert.Equal("TEST Line", fileForSearching.Lines[1]);
            Assert.Equal("MiXeD CaSe", fileForSearching.Lines[2]);

            Assert.Equal(3, fileForSearching.LowercaseLines.Count);
            Assert.Equal("hello world", fileForSearching.LowercaseLines[0]);
            Assert.Equal("test line", fileForSearching.LowercaseLines[1]);
            Assert.Equal("mixed case", fileForSearching.LowercaseLines[2]);
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }
}
