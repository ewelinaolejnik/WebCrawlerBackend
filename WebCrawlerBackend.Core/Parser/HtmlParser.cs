using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebCrawlerBackend.Core.Parser
{
    public class HtmlParser : IHtmlParser
    {
        public IEnumerable<string> GetImagesUrls(string htmlUrl)
        {
            List<string> urls = new List<string>();
            Uri uri = new Uri(htmlUrl);

            string html;
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(htmlUrl);

                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                foreach (HtmlNode img in htmlDocument.DocumentNode.SelectNodes("//img"))
                {
                    urls.Add(img.GetAttributeValue("src", null));
                }
            }

            return urls;
        }
    }
}
