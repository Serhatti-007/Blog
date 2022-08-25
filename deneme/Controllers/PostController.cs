using deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deneme.Controllers
{
    public class PostController : Controller
    {

        public readonly BlogPostDbContext _db;

        public PostController(BlogPostDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            return View();
        }


        // GET: TblPostsTemp/Details/5
        public async Task<IActionResult> Detail(int? id)
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
