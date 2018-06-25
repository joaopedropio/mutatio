using System.IO;
using System.Threading.Tasks;

namespace Mutatio
{
    public static class Archive
    {
        public static async Task SaveLogFile(string filePath, string text)
        {
            using (StreamWriter writer = File.CreateText(filePath))
            {
                await writer.WriteAsync(text);
            }
        }
    }
}
