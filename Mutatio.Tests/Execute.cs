using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Mutatio.Tests
{
    [TestClass]
    public class Execute
    {
        [TestMethod]
        public async Task Fluxo()
        {
            var url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var filePath = @"C:\Temp\itass.txt";
            await Program.Log(url, filePath, LogsFormatsEnum.MinhaCDN, LogsFormatsEnum.Agora);
        }
    }
}
