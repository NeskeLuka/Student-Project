using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class SmerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SmerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------
        // GET: /Smer/Index
        // Lista svih smerova
        // ------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var smerovi = await _context.Smerovi.ToListAsync();
            return View(smerovi);
        }

        // ------------------------------------------------------
        // GET: /Smer/Details/5
        // ------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var smer = await _context.Smerovi
                .FirstOrDefaultAsync(s => s.SmerId == id);

            if (smer == null)
                return NotFound();

            return View(smer);
        }

        // ------------------------------------------------------
        // GET: /Smer/Delete/5
        // ------------------------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var smer = await _context.Smerovi
                .FirstOrDefaultAsync(s => s.SmerId == id);

            if (smer == null)
                return NotFound();

            return View(smer);
        }

        // ------------------------------------------------------
        // GET: /Smer/DetailsWithStudenti/5
        // Prikazuje smer sa svim studentima
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithStudenti(int? id)
        {
            if (id == null)
                return NotFound();

            var smer = await _context.Smerovi
                .Include(s => s.Studenti)
                .FirstOrDefaultAsync(s => s.SmerId == id);

            if (smer == null)
                return NotFound();

            return View(smer);
        }

        // ------------------------------------------------------
        // GET: /Smer/DetailsWithPredmeti/5
        // Prikazuje smer sa svim predmetima
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithPredmeti(int? id)
        {
            if (id == null)
                return NotFound();

            var smer = await _context.Smerovi
                .Include(s => s.Predmeti)
                .FirstOrDefaultAsync(s => s.SmerId == id);

            if (smer == null)
                return NotFound();

            return View(smer);
        }
    }
}
