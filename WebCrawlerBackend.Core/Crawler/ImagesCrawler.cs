using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebCrawlerBackend.Core.Crawler;
using WebCrawlerBackend.Core.Downloader;
using WebCrawlerBackend.Core.Parser;

namespace WebCrawlerBackend.Core
{
    public class ImagesCrawler : IImagesCrawler
    {
        private readonly IHtmlParser _parser;
        private readonly IImagesDownloader _downloader;

        public ImagesCrawler(IHtmlParser parser, IImagesDownloader downloader)
        {
            _parser = parser;
            _downloader = downloader;
        }

        public IEnumerable<Image> GetImages(CrawlerInput input)
        {
            var imagesUrls = _parser.GetImagesUrls(input.Url);
            var imagesPaths = _downloader.GetImagesPaths(imagesUrls, input.ImagesFolderPath);
            return imagesPaths.Select(i => new Image(i));
        }
    }
}
