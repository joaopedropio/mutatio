using Registrum.BaseLog;
using Registrum.Logs;
using System;

namespace Registrum
{
    public static class Logger
    {
        public static string Conversion(string file, LogFormatEnum inputType, LogFormatEnum outputType)
        {
            var baseLog = ToHttpBaseLog(file, inputType);

            return FromHttpBaseLog(baseLog, outputType);
        }

        internal static IHttpBaseLog ToHttpBaseLog(string log, LogFormatEnum inputType)
        {
            switch (inputType)
            {
                case LogFormatEnum.MinhaCDN:
                    return new MinhaCDN(log).ToHttpBaseLog();
                case LogFormatEnum.Agora:
                    return new Agora(log).ToHttpBaseLog();
                default:
                    throw new NotImplementedException();
            }
        }

        internal static string FromHttpBaseLog(IHttpBaseLog log, LogFormatEnum inputType)
        {
            switch (inputType)
            {
                case LogFormatEnum.MinhaCDN:
                    return new MinhaCDN(log).Content;
                case LogFormatEnum.Agora:
                    return new Agora(log).Content;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
