using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Education.Data;
using Education.Models;

namespace Education.Controllers
{
    public class Thr3adController : Controller
    {
        private readonly EducationContext _context;

        public Thr3adController(EducationContext context)
        {
            _context = context;
        }

        // GET: Thr3ad
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.Thr3ad == null)
            {
                return Problem("Entity set 'EducationContext.Thr3ad'  is null.");
            }

            var threads = from m in _context.Thr3ad
                          select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                threads = threads.Where(s => s.Title!.Contains(searchString));
            }

            return View(await threads.ToListAsync());
        }

        // GET: Thr3ad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Thr3ad == null)
            {
                return NotFound();
            }

            var thr3ad = await _context.Thr3ad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thr3ad == null)
            {
                return NotFound();
            }

            return View(thr3ad);
        }

        // GET: Thr3ad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thr3ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Content")] Thr3ad thr3ad)
        {

            if (ModelState.IsValid)
            {
                _context.Add(thr3ad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thr3ad);
        }

        // GET: Thr3ad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Thr3ad == null)
            {
                return NotFound();
            }

            var thr3ad = await _context.Thr3ad.FindAsync(id);
            if (thr3ad == null)
            {
                return NotFound();
            }
            return View(thr3ad);
        }

        // POST: Thr3ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,UploadDate,Author,Content")] Thr3ad thr3ad)
        {
            if (id != thr3ad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thr3ad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Thr3adExists(thr3ad.Id))
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
            return View(thr3ad);
        }

        // GET: Thr3ad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Thr3ad == null)
            {
                return NotFound();
            }

            var thr3ad = await _context.Thr3ad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thr3ad == null)
            {
                return NotFound();
            }

            return View(thr3ad);
        }

        // POST: Thr3ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Thr3ad == null)
            {
                return Problem("Entity set 'EducationContext.Thr3ad'  is null.");
            }
            var thr3ad = await _context.Thr3ad.FindAsync(id);
            if (thr3ad != null)
            {
                _context.Thr3ad.Remove(thr3ad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Thr3adExists(int id)
        {
            return (_context.Thr3ad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
