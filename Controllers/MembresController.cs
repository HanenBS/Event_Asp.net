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
    public class MembresController : Controller
    {
        private readonly ApplicationContexte _context;

        public MembresController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Membres
        public async Task<IActionResult> Index()
        {
            return _context.membres != null ?
                        View(await _context.membres.ToListAsync()) :
                        Problem("Entity set 'ApplicationContexte.membres'  is null.");
        }

        // GET: Membres/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.membres == null)
            {
                return NotFound();
            }

            var membre = await _context.membres
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // GET: Membres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Age,AddrMail,MotDePasse,Sexe")] Membre membre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membre);
        }

        // GET: Membres/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.membres == null)
            {
                return NotFound();
            }

            var membre = await _context.membres.FindAsync(id);
            if (membre == null)
            {
                return NotFound();
            }
            return View(membre);
        }

        // POST: Membres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Age,AddrMail,MotDePasse,Sexe")] Membre membre)
        {
            if (id != membre.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembreExists(membre.Nom))
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
            return View(membre);
        }

        // GET: Membres/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.membres == null)
            {
                return NotFound();
            }

            var membre = await _context.membres
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (membre == null)
            {
                return NotFound();
            }

            return View(membre);
        }

        // POST: Membres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.membres == null)
            {
                return Problem("Entity set 'ApplicationContexte.membres'  is null.");
            }
            var membre = await _context.membres.FindAsync(id);
            if (membre != null)
            {
                _context.membres.Remove(membre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembreExists(string id)
        {
            return (_context.membres?.Any(e => e.Nom == id)).GetValueOrDefault();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var membre = _context.membres.FirstOrDefault(m => m.AddrMail == email && m.MotDePasse == password);

            if (membre != null)
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
