/*using efcoreApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class WishListController : Controller
    {
        private readonly IdentityContext _context;
        public WishListController(IdentityContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if(!User.IsInRole("member"))
            {
                return NotFound();
            }
            return View(GetWishList());
        }
        public async Task<IActionResult> AddToWishList(int GameId)
        {

            var game = await _context.Games.FirstOrDefaultAsync(i => i.GameId == GameId);
            if (game != null)
            {
                GetWishList().AddGame(game);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoveFromWishList(int GameId)
        {
            var game = _context.Games.FirstOrDefault(i => i.GameId == GameId);
            if (game != null)
            {
                GetWishList().DeleteGame(game);
            }
            return RedirectToAction("Index");

        }
        public WishList GetWishList()
        {
            var wishList = new WishList();

            return wishList;
        }
    }
}*/