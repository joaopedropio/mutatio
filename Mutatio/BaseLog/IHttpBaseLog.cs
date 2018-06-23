using System.Collections.Generic;

namespace Mutatio.BaseLog
{
    public interface IHttpBaseLog
    {
        List<IHttpLogEntry> LogEntries { get; set; }

        IHttpBaseLog ToHttpBaseLog();
    }
}
