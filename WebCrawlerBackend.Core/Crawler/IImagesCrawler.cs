using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebCrawlerBackend.Core.Crawler;

namespace WebCrawlerBackend.Core
{
    public interface IImagesCrawler
    {
        IEnumerable<Image> GetImages(CrawlerInput input);
    }
}
