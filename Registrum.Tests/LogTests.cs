using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registrum.Tests
{
    [TestClass]
    public class LogTests
    {
        string minhaCDNLog = @"312|200|HIT|""GET /robots.txt HTTP/1.1\""|100.2
101|200|MISS|""POST /myImages HTTP/1.1""|319.4
199|404|MISS|""GET /not-found HTTP/1.1""|142.9
312|200|INVALIDATE|""GET /robots.txt HTTP/1.1""|245.1";

        string agoraLog = @"#Version: 1.0
#Date: 15/12/2017 23:01:06
#Fields: provider http-method status-code uri-path time-taken response-size cache-status
""MINHA CDN"" GET 200 /robots.txt 100 312 HIT
""MINHA CDN"" POST 200 /myImages 319 101 MISS
""MINHA CDN"" GET 404 /not-found 143 199 MISS
""MINHA CDN"" GET 200 /robots.txt 245 312 REFRESH_HIT";

        [TestMethod]
        public void FromMinhaCDNToAgoraLog()
        {
            var log = agoraLog;
            var result = Log.Conversion(minhaCDNLog, LogFormatEnum.MinhaCDN, LogFormatEnum.Agora);

            log = removeDateLineFromAgoraLog(log);
            result = removeDateLineFromAgoraLog(result);

            Assert.AreEqual(log, result);
        }

        [TestMethod]
        public void FromAgoraToMinhaCDNLog()
        {
            var log = agoraLog;
            var result = Log.Conversion(minhaCDNLog, LogFormatEnum.Agora, LogFormatEnum.MinhaCDN);

            log = removeDateLineFromAgoraLog(log);
            result = removeDateLineFromAgoraLog(result);

            Assert.AreEqual(log, result);
        }

        private string removeDateLineFromAgoraLog(string agoraLog)
        {
            var lines = agoraLog.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            lines[1] = "";
            return lines.Aggregate((result, nextLine) => nextLine == "" ? result + nextLine : result + "\r\n" + nextLine);
        }
    }
}
