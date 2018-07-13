using System.IO;

namespace Mutatio
{
    public static class Archive
    {
        public static void SaveLogFile(string filePath, string text)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                writer.Write(text);
            }
        }
    }
}
