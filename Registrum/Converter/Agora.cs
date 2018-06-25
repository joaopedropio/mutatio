using Registrum.BaseLog;
using System;

namespace Registrum.Converter
{
    internal static class Agora
    {
        internal static string HttpBaseToAgoraLog(IHttpBaseLog httpBaseLog)
        {
            var metadata = string.Format(@"# Version: 1.0
# Date: {0} {1}
# Fields: provider http-method status-code uri-path time-taken response-size cache-status
", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

            var body = string.Empty;

            foreach (var log in httpBaseLog.LogEntries)
            {
                var timeTaken = decimal.Parse(log.TimeTaken.Replace('.', ','));
                log.TimeTaken = Math.Round(timeTaken, 0).ToString();
                log.CacheStatus = log.CacheStatus == "INVALIDATE" ? "REFRESH_HIT" : log.CacheStatus;

                body += string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}\r\n",
                    log.Provider, log.HttpMethod, log.StatusCode, log.URIPath, log.TimeTaken, log.ResponseSize, log.CacheStatus);
            }

            return metadata + body;
        }

        internal static IHttpBaseLog ToHttpBaseLog(string log)
        {
            return ToHttpBaseLog(log);
        }
    }
}
