using FileAndFolderFinder.App;

namespace FileAndFolderFinder.Tests
{
    public class FileSearcherUnitTest
    {
        [Fact]
        public void Search_ShouldFindFilesOrFoldersContainingKeywords()
        {
            string tempDirection = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirection);

            try
            {
                string testDirection = Path.Combine(tempDirection, "testFolder");
                Directory.CreateDirectory(testDirection);

                string testFile = Path.Combine(tempDirection, "test_file.txt");
                File.WriteAllText(testFile, "test");

                FileSearcher searcher = new FileSearcher();

                var results = searcher.Search(tempDirection, "test");

                Assert.Single(results.Directories);
                Assert.Single(results.Files);
                Assert.Contains(results.Directories, path => path.Contains("testFolder"));
                Assert.Contains(results.Files, path => path.Contains("test_file.txt"));
            }

            finally
            {
                Directory.Delete(tempDirection, true);
            }
        }
    }
}