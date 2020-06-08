using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawlerBackend.Core.Downloader
{
    public interface IImagesDownloader
    {
        IEnumerable<string> GetImagesPaths(IEnumerable<string> imagesUrls, string imagesFolderPath);
    }
}
