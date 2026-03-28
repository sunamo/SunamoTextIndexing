# SunamoTextIndexing

Fast searching in content of text files.

## Target Frameworks

**TargetFrameworks:** `net10.0;net9.0;net8.0`

## Features

- Load and index multiple text files for searching
- Case-insensitive search support via lowercase line indexing
- Asynchronous file loading
- Track search matches by line number

## Key Classes

- **TextIndexing** — Manages a collection of files indexed for fast text searching. Files are stored in a dictionary keyed by their full path.
- **FileForSearching** — Represents a single file loaded into memory with both original and lowercase lines for case-insensitive search operations.

## Usage

```csharp
var textIndexing = new TextIndexing();
textIndexing.ReloadFiles(new List<string> { "file1.txt", "file2.txt" });

foreach (var entry in textIndexing.Files)
{
    await entry.Value.Init();
}
```

## Installation

```bash
dotnet add package SunamoTextIndexing
```

## Dependencies

- **Microsoft.Extensions.Logging.Abstractions**

## License

MIT
