using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookCollection.Models;

namespace BookCollection.Controllers
{
    public class BookCategoriesController : Controller
    {
        private readonly BookContext _context;

        public BookCategoriesController(BookContext context)
        {
            _context = context;
        }

        // GET: BookCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookCategoriesModels.ToListAsync());
        }

        // GET: BookCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategoriesModel = await _context.BookCategoriesModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCategoriesModel == null)
            {
                return NotFound();
            }

            return View(bookCategoriesModel);
        }

        // GET: BookCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName")] BookCategoriesModel bookCategoriesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategoriesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategoriesModel);
        }

        // GET: BookCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategoriesModel = await _context.BookCategoriesModels.FindAsync(id);
            if (bookCategoriesModel == null)
            {
                return NotFound();
            }
            return View(bookCategoriesModel);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName")] BookCategoriesModel bookCategoriesModel)
        {
            if (id != bookCategoriesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategoriesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoriesModelExists(bookCategoriesModel.Id))
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
            return View(bookCategoriesModel);
        }

        // GET: BookCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCategoriesModel = await _context.BookCategoriesModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookCategoriesModel == null)
            {
                return NotFound();
            }

            return View(bookCategoriesModel);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCategoriesModel = await _context.BookCategoriesModels.FindAsync(id);
            _context.BookCategoriesModels.Remove(bookCategoriesModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoriesModelExists(int id)
        {
            return _context.BookCategoriesModels.Any(e => e.Id == id);
        }
    }
}
