using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Data;
using Project.Models;
namespace Project.Controllers
{
    public class PredmetController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PredmetController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /Predmet/Index
        // Prikazuje listu svih predmeta
        public async Task<IActionResult> Index()
        {
            var predmeti = await _context.Predmeti.ToListAsync();
            return View(predmeti);
        }

        // GET: /Predmet/Details/5
        // Prikazuje predmet
        public async Task<IActionResult> Details(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var predmet = await _context.Predmeti.FirstOrDefaultAsync(p => p.PredmetId == ID);
            if (predmet == null)
            {
                return NotFound();
            }
            return View(predmet);
        }
        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }
            var predmet = await _context.Predmeti.FirstOrDefaultAsync(p => p.PredmetId == ID);
            if (predmet == null)
            {
                return NotFound();
            }
            return View(predmet);
        }
        // ------------------------------------------------------
        // GET: /Predmet/Details/5
        // Prikazuje jedan predmet sa studentima koji ga slušaju
        // ------------------------------------------------------
        public async Task<IActionResult> DetailsWithStudent(int? id)
        {
            if (id == null)
                return NotFound();

            var predmet = await _context.Predmeti
                .Include(p => p.StudentiPredmeti)
                    .ThenInclude(sp => sp.Student)
                .FirstOrDefaultAsync(p => p.PredmetId == id);

            if (predmet == null)
                return NotFound();

            return View(predmet);
        }
        public async Task<IActionResult> DetailsWithProfesor(int? id)
        {
            if (id == null)
                return NotFound();

            var predmet = await _context.Predmeti
                .Include(p => p.ProfesoriPredmeti)
                    .ThenInclude(p => p.Profesor)
                .FirstOrDefaultAsync(p => p.PredmetId == id);

            if (predmet == null)
                return NotFound();

            return View(predmet);
        }
    }
}
