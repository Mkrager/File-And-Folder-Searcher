namespace FileAndFolderFinder.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var searchService = new SearchService();
            
            searchService.Start();
        }
    }
}