using deneme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme.Controllers
{
    public class AdminController : Controller
    {
        //Admin / Post Controller 
        public readonly BlogPostDbContext _db;

        public AdminController(BlogPostDbContext db)
        {
            _db = db;
        }

        public int getLength()
        {
            if(_db.TblPosts == null)
            {
                return 0; 
            }
            var length = _db.TblPosts.ToArray().Length;
            return length;
        }


        [Authorize]
        public IActionResult Index()
        {
            var postNumber = getLength();
            return View(postNumber);
        }


        public IActionResult Listele()
        {
            IEnumerable<TblPost> objCategoryList = _db.TblPosts.ToList();
            return View(objCategoryList);
        }

        //Create new post
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
        //Edit post 
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

        //Delete Post
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

        //See Details of a post
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _db.TblPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPost == null)
            {
                return NotFound();
            }

            return View(tblPost);
        }





    }
}
