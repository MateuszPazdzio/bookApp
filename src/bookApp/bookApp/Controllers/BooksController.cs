using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookApp;
using bookApp.Models;
using Bogus;

namespace bookApp.Controllers
{
    //[Route("books")]
    public class BooksController : Controller
    {
        private readonly BookAppContext _context;

        public BooksController(BookAppContext context)
        {
            _context = context;
        }

        // GET: Books
        [HttpGet]
        public async Task<IActionResult> Index()
        {
  
            return View(await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync());
        }

        // GET: Books/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}
        
    }
}
