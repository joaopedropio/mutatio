using System.Collections.Generic;

namespace Registrum.BaseLog
{
    internal interface IHttpBaseLog
    {
        List<IHttpLogEntry> LogEntries { get; set; }
    }
}
