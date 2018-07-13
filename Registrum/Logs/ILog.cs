using Registrum.BaseLog;

namespace Registrum.Logs
{
    internal interface ILog
    {
        string Content { get; set; }
        string FromHttpBaseLog(IHttpBaseLog httpBaseLog);
        IHttpBaseLog ToHttpBaseLog();
    }
}
