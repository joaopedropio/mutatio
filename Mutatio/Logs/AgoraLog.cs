using System.Collections.Generic;
using System;
using Mutatio.BaseLog;

namespace Mutatio.Logs
{
    public class AgoraLog : HttpBaseLog, IFormatedLog
    {
        public string FormatedLog { get; set; }

        public AgoraLog(List<IHttpLogEntry> logEntries)
        {
            this.LogEntries = logEntries;
            var result = string.Empty;

            foreach (var log in logEntries)
            {
                log.TimeTaken = log.TimeTaken.Split('.')[0];
                log.CacheStatus = log.CacheStatus == "INVALIDATE" ? "REFRESH_HIT" : log.CacheStatus;

                result += string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}\r\n",
                    log.Provider, log.HttpMethod, log.StatusCode, log.URIPath, log.TimeTaken, log.ResponseSize, log.CacheStatus);
            }

            this.FormatedLog = result;
        }

        public AgoraLog(IHttpBaseLog httpLog)
            : this(httpLog.LogEntries)
        { 

        }

        public override string ToString()
        {
            var metadata = string.Format(@"# Version: 1.0
# Date: {0} {1}
# Fields: provider http-method status-code uri-path time-taken response-size cache-status
", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());

            return metadata + this.FormatedLog;
        }

        public override IHttpBaseLog ToHttpBaseLog()
        {
            throw new NotImplementedException();
        }
    }
}
