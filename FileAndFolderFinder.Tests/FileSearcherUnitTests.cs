using FileAndFolderFinder.App;

namespace FileAndFolderFinder.Tests
{
    public class FileSearcherUnitTests
    {
        private readonly FileSearcher _searcher = new FileSearcher();

        [Fact]
        public void Search_ShouldFindFileContainingKeywords()
        {
            string tempDirection = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirection);

            try
            {
                string testFile = Path.Combine(tempDirection, "test_file.txt");
                File.WriteAllText(testFile, "test");

                var results = _searcher.Search(tempDirection, "test");

                Assert.Empty(results.Directories);
                Assert.Single(results.Files);
                Assert.Contains(testFile, results.Files);
            }

            finally
            {
                Directory.Delete(tempDirection, true);
            }
        }

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

                var results = _searcher.Search(tempDirection, "test");

                Assert.Single(results.Directories);
                Assert.Single(results.Files);
                Assert.Contains(testDirection, results.Directories);
                Assert.Contains(testFile, results.Files);
            }

            finally
            {
                Directory.Delete(tempDirection, true);
            }
        }

        [Fact]
        public void Search_ShouldReturnEmpty_WhenKeywordIsEmpty()
        {
            var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            try
            {
                var results = _searcher.Search(tempDir, "");

                Assert.Empty(results.Files);
                Assert.Empty(results.Directories);
            }
            finally
            {
                Directory.Delete(tempDir, true);
            }
        }

        [Fact]
        public void Search_ShouldThrowArgumentException_WhenDirectoryPathIsNullOrEmpty()
        {
            var invalidDir = "";

            Assert.Throws<ArgumentException>(() =>
            {
                _searcher.Search(invalidDir, "keyword");
            });
        }

        [Fact]
        public void Search_ShouldThrowDirectoryNotFoundException_WhenDirectoryDoesNotExist()
        {
            var invalidDir = "invalid path";

            Assert.Throws<DirectoryNotFoundException>(() =>
            {
                _searcher.Search(invalidDir, "keyword");
            });
        }

        [Fact]
        public void Search_ShouldThrowIOException_WhenPathContainsSpecialCharacters()
        {
            var invalidDir = "invalid path*";

            Assert.Throws<IOException>(() =>
            {
                _searcher.Search(invalidDir, "keyword");
            });
        }

    }
}