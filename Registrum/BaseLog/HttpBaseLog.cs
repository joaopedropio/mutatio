using System.Collections.Generic;

namespace Registrum.BaseLog
{
    internal class HttpBaseLog : IHttpBaseLog
    {
        public List<IHttpLogEntry> LogEntries { get; set; }

        internal HttpBaseLog(List<IHttpLogEntry> logEntries)
        {
            this.LogEntries = logEntries;
        }

        internal HttpBaseLog() : this(new List<IHttpLogEntry>())
        {

        }
    }
}
