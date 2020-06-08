using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebCrawlerBackend.Core.Crawler
{
    public class CrawlerInput
    {
        private readonly string _serverRootPath;

        private readonly string _imagesFolder;

        public string Url { get; }
        public string ImagesFolderPath => Path.Combine(_serverRootPath, _imagesFolder);

        public CrawlerInput(string serverRootPath, string imagesFolder, string url)
        {
            _serverRootPath = serverRootPath;
            _imagesFolder = imagesFolder;
            Url = url;

            if(!Directory.Exists(ImagesFolderPath))
            {
                Directory.CreateDirectory(ImagesFolderPath);
            }
        }
        
    }
}
