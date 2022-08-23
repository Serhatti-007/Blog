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



    }
}
