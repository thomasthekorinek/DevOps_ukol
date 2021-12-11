using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
namespace DevOps
{
    internal class DownloadPage
    {
        public async Task<string> GetHtml(string uriAdress)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var content = await client.GetStringAsync("https://www.cts-tradeit.cz"+uriAdress);

            return (content);
        }

    }
}
