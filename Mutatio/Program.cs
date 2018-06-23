using System;
using System.IO;
using System.Threading.Tasks;
using Mutatio.BaseLog;
using Mutatio.Logs;

namespace Mutatio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() => Log(args[0], args[1], LogsFormatsEnum.MinhaCDN, LogsFormatsEnum.Agora));
        }

        public static async Task Log(string url, string filePath, LogsFormatsEnum input, LogsFormatsEnum output)
        {
            var file = await Client.GetFile(url);

            var baseLog = ConvertToHttpBaseLog(file, input);

            var log = ConvertFromHttpBaseLog(baseLog, output);

            File.WriteAllText(filePath, log.ToString());
        }

        public static IHttpBaseLog ConvertToHttpBaseLog(string file, LogsFormatsEnum format)
        {
            switch (format)
            {
                case LogsFormatsEnum.MinhaCDN:
                    return new MinhaCDNLog(file).ToHttpBaseLog();
                default:
                    return new HttpBaseLog();
            }
        }

        public static IHttpBaseLog ConvertFromHttpBaseLog(IHttpBaseLog baseLog, LogsFormatsEnum format)
        {
            switch (format)
            {
                case LogsFormatsEnum.Agora:
                    return new AgoraLog(baseLog);
                default:
                    return baseLog;
            }
        }
    }
}