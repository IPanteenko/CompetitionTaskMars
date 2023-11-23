using System.Reflection;

namespace CompetitionTaskMars.Utilities
{
    internal class FileSystem
    {
        public static string GetRootDirectory()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (directoryName == null)
                throw new Exception("Couldn't get assembly directory");

            return directoryName;
        }

        public static void CreateDirectory(string directoryName)
        {
            Directory.CreateDirectory($"{GetRootDirectory()}\\{directoryName}");
        }
    }
}
