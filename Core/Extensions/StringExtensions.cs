using System.Reflection;

namespace Core.Extensions
{
    public static class StringExtensions
    {
        public static string GetAbsolutePath(this string filePath)
        {
            string directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);
            if (File.Exists(directoryPath)) 
            {
                return directoryPath;
            }
            return string.Empty;
        }

        public static string GetTextFromJsonFile(this string filePath)
        {
            string pathFile = filePath.GetAbsolutePath();
            return File.ReadAllText(pathFile);
        }
    }
}