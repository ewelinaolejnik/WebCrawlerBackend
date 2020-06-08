using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebCrawlerBackend.Core;

namespace WebCrawlerBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageCrawlerController : ControllerBase
    {
        private readonly IImagesCrawler _imagesCrawler;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageCrawlerController(IImagesCrawler imagesCrawler, IWebHostEnvironment hostingEnvironment)
        {
            _imagesCrawler = imagesCrawler;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult GetImages(string url)
        {
            try
            {
                //TODO: move images name folder to config
                var images = _imagesCrawler.GetImages(new Core.Crawler.CrawlerInput(_hostingEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "Images", url));
                var files = images.Select(i => i.ImagePath);
                return Ok(files);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.ToString() });
            }
        }
    }
}