## File and Folder Search Console App

A simple console application for searching files or folders by partial name.

### Features

- Search for files or folders by keyword.
- Specify a directory to search within.
- Saves the full paths of all found results to a `.txt` file.

### How It Works

1. You enter the path where you want to search.
2. You enter part of the name of the file or folder you're looking for.
3. The program searches recursively and writes all matching paths to an output text file.

### Example

Enter a directory path: C:\Users\Documents
Enter a keyword to search: report

Output:

```
Find 14 folders and 586 files
The result is written to a file: C:\Users\\source\repos\FolderAndFileSearcher\FileAndFolderFinder.App\bin\Debug\net8.0\results.txt
```

### Getting Started

1. Clone the repository to your local machine.

```bash
git clone https://github.com/Mkrager/File-And-Folder-Searcher.git
```
