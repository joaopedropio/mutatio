using System.Net.Http;
using System.Threading.Tasks;

namespace Mutatio
{
    public static class Client
    {
        public static async Task<string> GetFile(string url)
        {
            var http = new HttpClient();
            return await http.GetStringAsync(url);
        }
    }
}
