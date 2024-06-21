using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecom.Data;
using Ecom.Models;

namespace Ecom.Controllers
{
    public class ArtisansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtisansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Artisans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artisan.ToListAsync());
        }

        // GET: Artisans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artisan = await _context.Artisan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artisan == null)
            {
                return NotFound();
            }

            return View(artisan);
        }

        // GET: Artisans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artisans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Bio")] Artisan artisan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artisan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artisan);
        }

        // GET: Artisans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artisan = await _context.Artisan.FindAsync(id);
            if (artisan == null)
            {
                return NotFound();
            }
            return View(artisan);
        }

        // POST: Artisans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Bio")] Artisan artisan)
        {
            if (id != artisan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artisan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtisanExists(artisan.Id))
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
            return View(artisan);
        }

        // GET: Artisans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artisan = await _context.Artisan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artisan == null)
            {
                return NotFound();
            }

            return View(artisan);
        }

        // POST: Artisans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artisan = await _context.Artisan.FindAsync(id);
            if (artisan != null)
            {
                _context.Artisan.Remove(artisan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtisanExists(int id)
        {
            return _context.Artisan.Any(e => e.Id == id);
        }
    }
}
