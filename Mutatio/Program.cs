using Registrum;
using static System.Console;

namespace Mutatio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Execute(args[0], args[1], LogFormatEnum.MinhaCDN, LogFormatEnum.Agora);
            WriteLine("Done!");
        }

        private static void Execute(string url, string filePath, LogFormatEnum inputType, LogFormatEnum outputType)
        {
            WriteLine($"Downloading file from {url}");
            var file = Client.GetFile(url);

            WriteLine($"Converting log from {inputType.ToString()} to {outputType.ToString()}");
            var log = Logger.Conversion(file, inputType, outputType);

            WriteLine($"Saving log to {filePath}");
            Archive.SaveLogFile(filePath, log);
        }
    }
}