using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ------------------------------------------------------
        // GET: /Student/Index
        // Prikazuje sve studente
        // ------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            var studenti = await _context.Studenti
                .Include(s => s.Smer)
                .ToListAsync();

            return View(studenti);
        }

        // ------------------------------------------------------
        // GET: /Student/Details/5
        // Prikazuje jednog studenta
        // ------------------------------------------------------
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Studenti
                .Include(s => s.Smer)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // ------------------------------------------------------
        // GET: /Student/Delete/5
        // Potvrda brisanja studenta
        // ------------------------------------------------------
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Studenti
                .Include(s => s.Smer)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // ------------------------------------------------------
        // GET: /Student/DetailsWithPredmeti/5
        // Student + svi predmeti koje sluša
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithPredmeti(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Studenti
                .Include(s => s.StudentiPredmeti)
                    .ThenInclude(sp => sp.Predmet)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // ------------------------------------------------------
        // GET: /Student/DetailsWithSmer/5
        // Student + njegov smer (ako želiš posebno)
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithSmer(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Studenti
                .Include(s => s.Smer)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            if (student == null)
                return NotFound();

            return View(student);
        }
    }
}
