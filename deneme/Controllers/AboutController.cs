using deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.Abouts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About obj)
        {
            if (ModelState.IsValid)
            {
                _db.Abouts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }



    }
}
