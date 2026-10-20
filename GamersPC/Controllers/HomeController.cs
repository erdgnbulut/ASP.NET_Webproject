using efcoreApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace efcoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IdentityContext _context;
        public HomeController(IdentityContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Games.ToListAsync());
        }
        public async Task<IActionResult> Store()
        {
            return View(await _context.Games.ToListAsync());
        }

        public IActionResult Details(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
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