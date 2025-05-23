namespace FileAndFolderFinder.App
{
    public class FileSearcher
    {
        public (List<string> Files, List<string> Directories) Search(string directoryPath, string keyword)
        {
            var files = new List<string>();
            var directories = new List<string>();

            foreach (var path in Directory.EnumerateFileSystemEntries(directoryPath, "*", SearchOption.AllDirectories))
            {
                var name = Path.GetFileName(path);

                if (name != null && name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (File.Exists(path))
                        files.Add(path);
                    if (Directory.Exists(path))
                        directories.Add(path);
                }
            }

            return (files, directories);
        }
    }
}
