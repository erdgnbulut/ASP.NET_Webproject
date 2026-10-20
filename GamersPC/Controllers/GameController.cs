using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IdentityContext _context;
        public GameController(IdentityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if(!User.IsInRole("admin"))
            {
                return NotFound();
            }
            return View(await _context.Games.ToListAsync());
        }
        public IActionResult Create()
        {
            if(!User.IsInRole("admin"))
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game model)
        {
            _context.Games.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FirstOrDefaultAsync(o => o.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, Game model)
        {
            if (id != model.GameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Games.Any(o => o.GameId == model.GameId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult GetImage(int id)
        {
            var game = _context.Games.Find(id);
            if (game == null || game.GameImage == null)
            {
                return File("~/images/default-placeholder.jpg", "image/jpeg");
            }

            return File(game.GameImage, "image/jpeg");
        }

    }
}