using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WebCrawlerBackend.Core.Downloader
{
    public class ImagesDownloader : IImagesDownloader
    {
        const string imageName = "image";
        public IEnumerable<string> GetImagesPaths(IEnumerable<string> imagesUrls, string imagesFolderPath)
        {
            List<string> paths = new List<string>();
            foreach (var imageUrl in imagesUrls)
            {
                string imagePath = DownloadImage(imageUrl, imagesFolderPath);
                if(!string.IsNullOrEmpty(imagePath))
                {
                    paths.Add(imagePath);

                }
            }

            return paths;
        }

        public string DownloadImage(string imageUrl, string imagesFolderPath)
        {
            if(string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentNullException("Image Url is null or empty");
            }

            if (string.IsNullOrEmpty(imagesFolderPath))
            {
                throw new ArgumentNullException("Images Folder Path is null or empty");
            }

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string path = Path.Combine(imagesFolderPath, $"{imageName}_{DateTime.Now.ToString("yyyy-MM-ddHHmmss")}.jpeg");
                    webClient.DownloadFile(new Uri(imageUrl), path);
                    return path;
                }
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }

            return null;
            
        }
    }
}
