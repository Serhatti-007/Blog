using deneme.Models;
using Microsoft.AspNetCore.Mvc;

namespace deneme.Controllers
{
    public class AdminController : Controller
    {

        public readonly BlogPostDbContext _db;

        public AdminController(BlogPostDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Listele()
        {
            IEnumerable<TblPost> objCategoryList = _db.TblPosts.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TblPost obj)
        {
            if (ModelState.IsValid)
            {
                _db.TblPosts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Listele");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.TblPosts.Find(id);
            if(post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TblPost post)
        {
            if (ModelState.IsValid)
            {
                post.UpdatedTime = DateTime.Now;
                post.CreatedTime = DateTime.Now;//TODO: created time update time ile ayni
                _db.TblPosts.Update(post);
                _db.SaveChanges();
                return RedirectToAction("Listele");
            }
            return View(post);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = _db.TblPosts.Find(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.TblPosts.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.TblPosts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Listele");
        }



    }
}
