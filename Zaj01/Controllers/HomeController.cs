using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using Zaj01.Models;

namespace Zaj01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //MVC
        [HttpGet]
        public IActionResult Index()
        {
            var technologies = new List<Technology>()
            {
                new Technology{ Name = "C#", WhenToLearn = DateTime.Now.AddDays(-1) },
                new Technology{ Name = "React", WhenToLearn = DateTime.Now.AddDays(-1) },
                new Technology{ Name = "Asp.NET", WhenToLearn = DateTime.Now.AddDays(-1) },
                
            };
            return View("Technologies", technologies);
        }

        public IActionResult DisplayNews()
        {
            var rss = XElement.Load("https://news.google.com/rss?topic=h&hl=pl&gl=PL&ceid=PL:pl");

            var news = rss.Descendants("item")
                .Select(item => new RssItem
            {
                Title = item.Element("title").Value,
                PubDate = item.Element("pubDate").Value,
                Desc = item.Element("description").Value,
            }).ToList();

            return View(news);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}