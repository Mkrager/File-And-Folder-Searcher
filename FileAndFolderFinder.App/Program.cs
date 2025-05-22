using FileAndFolderFinder.App;

FileSearcher fileSearcher = new FileSearcher();

string path = Console.ReadLine();

string keyword = Console.ReadLine();

var result = fileSearcher.Search(path, keyword);

Console.ReadLine();