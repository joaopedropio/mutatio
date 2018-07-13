using System.Net.Http;

namespace Mutatio
{
    public static class Client
    {
        public static string GetFile(string url)
        {
            var http = new HttpClient();
            return http.GetStringAsync(url).Result;
        }
    }
}
