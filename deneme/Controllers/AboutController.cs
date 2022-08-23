using deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Controllers
{
    public class AboutController : Controller
    {
        public readonly BlogPostDbContext _db; 

        public AboutController(BlogPostDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<About> list = _db.Abouts.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }




    }
}
