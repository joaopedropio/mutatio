using Registrum.BaseLog;
using Registrum.Converter;
using System;

namespace Registrum
{
    public static class Log
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
                    return MinhaCDN.ToHttpBaseLog(log);
                case LogFormatEnum.Agora:
                    return Agora.ToHttpBaseLog(log);
                default:
                    throw new NotImplementedException();
            }
        }

        internal static string FromHttpBaseLog(IHttpBaseLog log, LogFormatEnum inputType)
        {
            switch (inputType)
            {
                case LogFormatEnum.MinhaCDN:
                    return MinhaCDN.HttpBaseToMinhaCDN(log);
                case LogFormatEnum.Agora:
                    return Agora.HttpBaseToAgoraLog(log);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
