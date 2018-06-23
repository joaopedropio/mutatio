using System.Collections.Generic;

namespace Mutatio.BaseLog
{
    public class HttpBaseLog : IHttpBaseLog
    {
        public List<IHttpLogEntry> LogEntries { get; set; }

        public HttpBaseLog(List<IHttpLogEntry> logEntries)
        {
            this.LogEntries = logEntries;
        }

        public HttpBaseLog() : this(new List<IHttpLogEntry>())
        {

        }

        public virtual IHttpBaseLog ToHttpBaseLog()
        {
            return this;
        }
    }
}
