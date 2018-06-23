using System;
using System.Collections.Generic;
using Mutatio.BaseLog;

namespace Mutatio.Logs
{
    class MinhaCDNLog : HttpBaseLog, IFormatedLog 
    {
        public string FormatedLog { get; set; }

        public MinhaCDNLog(string formatedLog)
        {
            this.FormatedLog = formatedLog;
        }

        public override IHttpBaseLog ToHttpBaseLog()
        {
            var lines = this.FormatedLog.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

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
    }
}
