using deneme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogPostDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BlogPostDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            IEnumerable<About> liste = _db.Abouts.ToList();
            return View(liste);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Posts()
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