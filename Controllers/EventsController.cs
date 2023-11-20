using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ahmedHanen.Models;

namespace ahmedHanen.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationContexte _context;

        public EventsController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
              return _context.events != null ? 
                          View(await _context.events.ToListAsync()) :
                          Problem("Entity set 'ApplicationContexte.events'  is null.");
        }

        public async Task<IActionResult> liste()
        {
            return _context.events != null ?
                        View(await _context.events.ToListAsync()) :
                        Problem("Entity set 'ApplicationContexte.events'  is null.");
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.events == null)
            {
                return NotFound();
            }

            var @event = await _context.events
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Date,Lieu,Description,Type")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.events == null)
            {
                return NotFound();
            }

            var @event = await _context.events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Date,Lieu,Description,Type")] Event @event)
        {
            if (id != @event.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Nom))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.events == null)
            {
                return NotFound();
            }

            var @event = await _context.events
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.events == null)
            {
                return Problem("Entity set 'ApplicationContexte.events'  is null.");
            }
            var @event = await _context.events.FindAsync(id);
            if (@event != null)
            {
                _context.events.Remove(@event);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(string id)
        {
          return (_context.events?.Any(e => e.Nom == id)).GetValueOrDefault();
        }
    }
}
