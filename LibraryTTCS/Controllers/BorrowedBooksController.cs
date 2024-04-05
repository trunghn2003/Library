using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryTTCS.Data;
using LibraryTTCS.Models;

namespace LibraryTTCS.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private readonly LibraryTTCSContext _context;

        public BorrowedBooksController(LibraryTTCSContext context)
        {
            _context = context;
        }

        // GET: BorrowedBooks
        public async Task<IActionResult> Index()
        {
            var libraryTTCSContext = _context.BorrowedBook.Include(b => b.Book).Include(b => b.Borrowing);
            return View(await libraryTTCSContext.ToListAsync());
        }

        // GET: BorrowedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook
                .Include(b => b.Book)
                .Include(b => b.Borrowing)
                .FirstOrDefaultAsync(m => m.BorrowedBookID == id);
            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Create
        public IActionResult Create()
        {
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID");
            ViewData["BorrowingID"] = new SelectList(_context.Borrowing, "BorrowingID", "BorrowingID");
            return View();
        }

        // POST: BorrowedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowedBookID,BorrowingID,BookID")] BorrowedBook borrowedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", borrowedBook.BookID);
            ViewData["BorrowingID"] = new SelectList(_context.Borrowing, "BorrowingID", "BorrowingID", borrowedBook.BorrowingID);
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook.FindAsync(id);
            if (borrowedBook == null)
            {
                return NotFound();
            }
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", borrowedBook.BookID);
            ViewData["BorrowingID"] = new SelectList(_context.Borrowing, "BorrowingID", "BorrowingID", borrowedBook.BorrowingID);
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowedBookID,BorrowingID,BookID")] BorrowedBook borrowedBook)
        {
            if (id != borrowedBook.BorrowedBookID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowedBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowedBookExists(borrowedBook.BorrowedBookID))
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
            ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", borrowedBook.BookID);
            ViewData["BorrowingID"] = new SelectList(_context.Borrowing, "BorrowingID", "BorrowingID", borrowedBook.BorrowingID);
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook
                .Include(b => b.Book)
                .Include(b => b.Borrowing)
                .FirstOrDefaultAsync(m => m.BorrowedBookID == id);
            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrowedBook = await _context.BorrowedBook.FindAsync(id);
            if (borrowedBook != null)
            {
                _context.BorrowedBook.Remove(borrowedBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowedBookExists(int id)
        {
            return _context.BorrowedBook.Any(e => e.BorrowedBookID == id);
        }
    }
}
