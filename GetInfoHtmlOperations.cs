using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevOps
{

    internal class GetInfoHtmlOperations
    {
        public string GetInfoRaw(string htmlCode)
        {
            string htmlCodeInner = htmlCode;
            string info = "";


            Regex filterName = new Regex(@"<section class=""section section--default"">[\w\W]*?(<\/section>)");

            
                var matchName = filterName.Match(htmlCodeInner);

                if (matchName.Success)
                {
                    info = matchName.Value;
                }

            //Console.WriteLine(info);
            return info;
        }
        public string ExtractText(string html)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            var chunks = new List<string>();

            foreach (var item in doc.DocumentNode.DescendantNodesAndSelf())
            {
                if (item.NodeType == HtmlNodeType.Text)
                {
                    if (item.InnerText.Trim() != "")
                    {
                        chunks.Add(item.InnerText.Trim());
                    }
                }
            }
            
            return String.Join(" ", chunks);
        }
    }
}