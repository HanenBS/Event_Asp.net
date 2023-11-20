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
    public class AdminsController : Controller
    {
        private readonly ApplicationContexte _context;

        public AdminsController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            return _context.admins != null ?
                View(await _context.admins.ToListAsync()) :
                Problem("Entity set 'ApplicationContexte.admins'  is null.");
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var admin = await _context.admins
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Email,MotDePasse")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var admin = await _context.admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Prenom,Email,MotDePasse")] Admin admin)
        {
            if (id != admin.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Nom))
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
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.admins == null)
            {
                return NotFound();
            }

            var admin = await _context.admins
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.admins == null)
            {
                return Problem("Entity set 'ApplicationContexte.admins'  is null.");
            }
            var admin = await _context.admins.FindAsync(id);
            if (admin != null)
            {
                _context.admins.Remove(admin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(string id)
        {
            return (_context.admins?.Any(e => e.Nom == id)).GetValueOrDefault();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var admin = _context.admins.FirstOrDefault(a => a.Email == email && a.MotDePasse == password);

            if (admin != null)
            {
                // Connexion réussie
                return Ok();
            }
            else
            {
                // Identifiants invalides
                return BadRequest();
            }
        }
    }
}
