using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawlerBackend.Core.Parser
{
    public interface IHtmlParser
    {
        IEnumerable<string> GetImagesUrls(string htmlUrl);
    }
}
