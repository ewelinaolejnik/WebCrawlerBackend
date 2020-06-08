using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebCrawlerBackend.Core
{
    public class Image
    {
        public string ImagePath { get; }

        public Image(string imagePath)
        {
            ImagePath = imagePath;
        }
    }
}
