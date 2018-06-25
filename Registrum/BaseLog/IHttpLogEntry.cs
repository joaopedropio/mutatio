namespace Registrum.BaseLog
{
    internal interface IHttpLogEntry
    {
        string Provider { get; set; }
        string HttpMethod { get; set; }
        string StatusCode { get; set; }
        string URIPath { get; set; }
        string TimeTaken { get; set; }
        string ResponseSize { get; set; }
        string CacheStatus { get; set; }
    }
}
