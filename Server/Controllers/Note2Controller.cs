using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Controllers
{
    public class Note2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Note2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Note2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Note2s.ToListAsync());
        }

        // GET: Note2/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note2 = await _context.Note2s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note2 == null)
            {
                return NotFound();
            }

            return View(note2);
        }

        // GET: Note2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Note2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content")] Note2 note2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(note2);
        }

        // GET: Note2/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note2 = await _context.Note2s.FindAsync(id);
            if (note2 == null)
            {
                return NotFound();
            }
            return View(note2);
        }

        // POST: Note2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Content")] Note2 note2)
        {
            if (id != note2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Note2Exists(note2.Id))
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
            return View(note2);
        }

        // GET: Note2/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var note2 = await _context.Note2s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (note2 == null)
            {
                return NotFound();
            }

            return View(note2);
        }

        // POST: Note2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var note2 = await _context.Note2s.FindAsync(id);
            if (note2 != null)
            {
                _context.Note2s.Remove(note2);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Note2Exists(long id)
        {
            return _context.Note2s.Any(e => e.Id == id);
        }
    }
}
