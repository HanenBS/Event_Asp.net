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
    public class OrganisateursController : Controller
    {
        private readonly ApplicationContexte _context;

        public OrganisateursController(ApplicationContexte context)
        {
            _context = context;
        }

        // GET: Organisateurs
        public async Task<IActionResult> Index()
        {
              return _context.organisateurs != null ? 
                          View(await _context.organisateurs.ToListAsync()) :
                          Problem("Entity set 'ApplicationContexte.organisateurs'  is null.");
        }

        // GET: Organisateurs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.organisateurs == null)
            {
                return NotFound();
            }

            var organisateur = await _context.organisateurs
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // GET: Organisateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Prenom,Age,Adresse,Email,MotDePasse,Sexe,Description")] Organisateur organisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organisateur);
        }

        // GET: Organisateurs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.organisateurs == null)
            {
                return NotFound();
            }

            var organisateur = await _context.organisateurs.FindAsync(id);
            if (organisateur == null)
            {
                return NotFound();
            }
            return View(organisateur);
        }

        // POST: Organisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nom,Prenom,Age,Adresse,Email,MotDePasse,Sexe,Description")] Organisateur organisateur)
        {
            if (id != organisateur.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisateurExists(organisateur.Nom))
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
            return View(organisateur);
        }

        // GET: Organisateurs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.organisateurs == null)
            {
                return NotFound();
            }

            var organisateur = await _context.organisateurs
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // POST: Organisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.organisateurs == null)
            {
                return Problem("Entity set 'ApplicationContexte.organisateurs'  is null.");
            }
            var organisateur = await _context.organisateurs.FindAsync(id);
            if (organisateur != null)
            {
                _context.organisateurs.Remove(organisateur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisateurExists(string id)
        {
          return (_context.organisateurs?.Any(e => e.Nom == id)).GetValueOrDefault();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var membre = _context.organisateurs.FirstOrDefault(m => m.Email == email && m.MotDePasse == password);

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
