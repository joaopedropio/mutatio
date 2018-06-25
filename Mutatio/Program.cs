using System.Threading.Tasks;
using Mutatio;

namespace Registrum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() => Execute(args[0], args[1], LogFormatEnum.MinhaCDN, LogFormatEnum.Agora));
        }

        private static async Task Execute(string url, string filePath, LogFormatEnum inputType, LogFormatEnum outputType)
        {
            var file = await Client.GetFile(url);

            var log = Log.Conversion(file, inputType, outputType);

            await Archive.SaveLogFile(filePath, log);
        }
    }
}