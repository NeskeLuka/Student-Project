using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------
        // GET: /Profesor/Index
        // ------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var profesori = await _context.Profesori.ToListAsync();
            return View(profesori);
        }

        // ------------------------------------------------------
        // GET: /Profesor/Details/5
        // ------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var profesor = await _context.Profesori
                .FirstOrDefaultAsync(p => p.ProfesorId == id);

            if (profesor == null)
                return NotFound();

            return View(profesor);
        }

        // ------------------------------------------------------
        // GET: /Profesor/Delete/5
        // ------------------------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var profesor = await _context.Profesori
                .FirstOrDefaultAsync(p => p.ProfesorId == id);

            if (profesor == null)
                return NotFound();

            return View(profesor);
        }

        // ------------------------------------------------------
        // GET: /Profesor/DetailsWithPredmeti/5
        // Prikazuje profesora i sve predmete koje predaje
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithPredmeti(int? id)
        {
            if (id == null)
                return NotFound();

            var profesor = await _context.Profesori
                .Include(p => p.ProfesoriPredmeti)
                    .ThenInclude(pp => pp.Predmet)
                .FirstOrDefaultAsync(p => p.ProfesorId == id);

            if (profesor == null)
                return NotFound();

            return View(profesor);
        }
    }
}
