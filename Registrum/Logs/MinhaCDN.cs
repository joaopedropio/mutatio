using Registrum.BaseLog;
using System;
using System.Collections.Generic;

namespace Registrum.Logs
{
    internal class MinhaCDN : ILog
    {
        public string Content { get; set; }
        public MinhaCDN(string log)
        {
            this.Content = log;
        }
        public MinhaCDN(IHttpBaseLog httpBaseLog)
        {
            this.Content = FromHttpBaseLog(httpBaseLog);
        }
        public IHttpBaseLog ToHttpBaseLog()
        {
            var lines = this.Content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var logEntries = new List<IHttpLogEntry>();

            foreach (var line in lines)
            {
                var x = line.Replace("\"", "");
                var y = x.Split('|');
                var z = y[3].Split(' ');
                var logEntry = new HttpLogEntry();
                logEntry.Provider = "MINHA CDN";
                logEntry.ResponseSize = y[0];
                logEntry.StatusCode = y[1];
                logEntry.CacheStatus = y[2];
                logEntry.HttpMethod = z[0];
                logEntry.URIPath = z[1];
                logEntry.TimeTaken = y[4];
                logEntries.Add(logEntry);
            }

            return new HttpBaseLog(logEntries);
        }

        public string FromHttpBaseLog(IHttpBaseLog log)
        {
            throw new NotImplementedException();
        }
    }
}
