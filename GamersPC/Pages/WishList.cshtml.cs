using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourProject.Extensions;

namespace GamersPC.Pages {
public class WishListModel : PageModel
  {  
    private IdentityContext _context;
    public WishListModel(IdentityContext context, WishList wishlistService)
    {
            _context=context;
            WishList = wishlistService;

    }
    public WishList? WishList { get; set; }
    public void OnGet()
    {

    }
    public IActionResult OnPost(int GameId)
    {
        var game = _context.Games.FirstOrDefault(i=>i.GameId == GameId);
        if (game != null)
        {
            WishList?.Add(game,1);

        }
        return RedirectToPage("/wishlist");


    }
    public IActionResult OnPostRemove(int GameId)
    {
      WishList?.RemoveItem(WishList.Items.First(i=>i.Game.GameId == GameId).Game);
      
      return RedirectToPage("/WishList");
    }

  }
}