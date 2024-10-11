using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookApp;
using bookApp.Models;

namespace bookApp.Controllers
{
    [Route("admin/books")]
    public class AdminController : Controller
    {
        private readonly BookAppContext _context;

        public AdminController(BookAppContext context)
        {
            _context = context;
        }

        // GET: Admin
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookPositions.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPosition = await _context.BookPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPosition == null)
            {
                return NotFound();
            }

            return View(bookPosition);
        }

        // GET: Admin/Create
        [HttpGet("create")]
        public  async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(new BookPosition());
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibraryQuantity,IsAvailable,IsTransferableToStore,SellingPrice,RentalFee")] BookPosition bookPosition)
        {
            if (ModelState.IsValid)
            {
                bookPosition.Id = Guid.NewGuid();
                _context.Add(bookPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookPosition);
        }

        // GET: Admin/Edit/5
        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPosition = await _context.BookPositions.FindAsync(id);
            if (bookPosition == null)
            {
                return NotFound();
            }
            return View(bookPosition);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,LibraryQuantity,IsAvailable,IsTransferableToStore,SellingPrice,RentalFee")] BookPosition bookPosition)
        {
            if (id != bookPosition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPositionExists(bookPosition.Id))
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
            return View(bookPosition);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPosition = await _context.BookPositions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPosition == null)
            {
                return NotFound();
            }

            return View(bookPosition);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bookPosition = await _context.BookPositions.FindAsync(id);
            if (bookPosition != null)
            {
                _context.BookPositions.Remove(bookPosition);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPositionExists(Guid id)
        {
            return _context.BookPositions.Any(e => e.Id == id);
        }
    }
}
