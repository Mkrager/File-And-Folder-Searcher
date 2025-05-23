namespace FileAndFolderFinder.App
{
    public class SearchService
    {
        public void Start()
        {
            while (true)
            {
                RunSearchHandler();

                Console.WriteLine("Press Q to quit or any key for search again");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Q)
                    break;

                Console.Clear();
            }
        }

        private void RunSearchHandler()
        {
            string directoryPath = GetPath();

            string searchKeyword = GetSearchKeyword();

            RunSearch(directoryPath, searchKeyword);
        }

        void RunSearch(string directoryPath, string searchKeyword)
        {
            var searcher = new FileSearcher();

            try
            {
                var results = searcher.Search(directoryPath, searchKeyword);

                if (results.Directories.Count == 0 && results.Files.Count == 0)
                {
                    WriteError($"There is no files and folders that contains: {searchKeyword}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Find {results.Directories.Count} folders and {results.Files.Count} files");

                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "results.txt");

                    var content = new List<string>();

                    content.Add("Folders:");
                    content.AddRange(results.Directories);

                    content.Add("Files:");
                    content.AddRange(results.Files);

                    File.WriteAllLines(outputPath, content);

                    Console.WriteLine($"The result is written to a file: {outputPath}");
                }
            }
            catch (Exception ex)
            {
                WriteError(ex.ToString());
            }
        }

        string GetSearchKeyword()
        {
            string searchKeyword;

            Console.Write("Enter a keyword to search: ");
            do
            {
                searchKeyword = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    WriteError("Empty keyword. Please enter a keyword to search: ");
                    continue;
                }

                break;
            } while (true);

            return searchKeyword;
        }

        string GetPath()
        {
            string directoryPath;
            Console.Write("Enter a directory path: ");

            do
            {

                directoryPath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(directoryPath))
                {
                    WriteError("Empty input. Please type valid source: ");
                    continue;
                }

                if (!Directory.Exists(directoryPath))
                {
                    WriteError("Invalid directory. Please type valid source: ");
                    continue;
                }

                break;
            }
            while (true);

            return directoryPath;
        }

        void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Error: {message}");
            Console.ResetColor();
        }

    }
}
