using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedProgramming_Lesson1.Data;
using AdvancedProgramming_Lesson1.Models.Bookstore;

namespace AdvancedProgramming_Lesson1.Controllers
{
    public class ksiazkasController : Controller
    {
        private readonly MvcMovieContext _context;

        public ksiazkasController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: ksiazkas
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Ksiazka.Include(k => k.Author).Include(k => k.Genre);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: ksiazkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Author)
                .Include(k => k.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // GET: ksiazkas/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.author, "Id", "CountryOfOrigin");
            ViewData["GenreId"] = new SelectList(_context.genres, "Id", "Themes");
            return View();
        }

        // POST: ksiazkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,YearOfRelease,GenreId,AuthorId,PagesCount,ListPrice")] ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.author, "Id", "CountryOfOrigin", ksiazka.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.genres, "Id", "Themes", ksiazka.GenreId);
            return View(ksiazka);
        }

        // GET: ksiazkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.author, "Id", "CountryOfOrigin", ksiazka.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.genres, "Id", "Themes", ksiazka.GenreId);
            return View(ksiazka);
        }

        // POST: ksiazkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,YearOfRelease,GenreId,AuthorId,PagesCount,ListPrice")] ksiazka ksiazka)
        {
            if (id != ksiazka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ksiazkaExists(ksiazka.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.author, "Id", "CountryOfOrigin", ksiazka.AuthorId);
            ViewData["GenreId"] = new SelectList(_context.genres, "Id", "Themes", ksiazka.GenreId);
            return View(ksiazka);
        }

        // GET: ksiazkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazka
                .Include(k => k.Author)
                .Include(k => k.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: ksiazkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiazka = await _context.Ksiazka.FindAsync(id);
            _context.Ksiazka.Remove(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ksiazkaExists(int id)
        {
            return _context.Ksiazka.Any(e => e.Id == id);
        }
    }
}
