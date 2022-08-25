using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using deneme.Models;

namespace deneme.Controllers
{
    public class TblPostsTempController : Controller
    {
        private readonly BlogPostDbContext _context;

        public TblPostsTempController(BlogPostDbContext context)
        {
            _context = context;
        }

        // GET: TblPostsTemp
        public async Task<IActionResult> Index()
        {
              return _context.TblPosts != null ? 
                          View(await _context.TblPosts.ToListAsync()) :
                          Problem("Entity set 'BlogPostDbContext.TblPosts'  is null.");
        }

        // GET: TblPostsTemp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPost == null)
            {
                return NotFound();
            }

            return View(tblPost);
        }

        // GET: TblPostsTemp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPostsTemp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Body,CreatedTime,UpdatedTime,PostResim")] TblPost tblPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPost);
        }

        // GET: TblPostsTemp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts.FindAsync(id);
            if (tblPost == null)
            {
                return NotFound();
            }
            return View(tblPost);
        }

        // POST: TblPostsTemp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Body,CreatedTime,UpdatedTime,PostResim")] TblPost tblPost)
        {
            if (id != tblPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPostExists(tblPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblPost);
        }

        // GET: TblPostsTemp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblPosts == null)
            {
                return NotFound();
            }

            var tblPost = await _context.TblPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPost == null)
            {
                return NotFound();
            }

            return View(tblPost);
        }

        // POST: TblPostsTemp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblPosts == null)
            {
                return Problem("Entity set 'BlogPostDbContext.TblPosts'  is null.");
            }
            var tblPost = await _context.TblPosts.FindAsync(id);
            if (tblPost != null)
            {
                _context.TblPosts.Remove(tblPost);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPostExists(int id)
        {
          return (_context.TblPosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
