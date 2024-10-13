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
        private readonly IBookPositionRepository _bookPositionRepository;

        public AdminController(BookAppContext context, IBookPositionRepository bookPositionRepository)
        {
            _context = context;
            this._bookPositionRepository = bookPositionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.BookPositions.ToListAsync());
        }

        [HttpGet("create")]
        public  async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(new BookPosition());
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookPosition bookPosition)
        {
            if (ModelState.IsValid)
            {
                var result = this._bookPositionRepository.AddBookPosition(bookPosition);
                if (result == null)
                {
                    return View(bookPosition);

                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(bookPosition);
        }
    }
}
