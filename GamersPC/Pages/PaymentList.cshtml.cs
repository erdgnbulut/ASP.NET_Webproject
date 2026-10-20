using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YourProject.Extensions;

namespace GamersPC.Pages {
public class PaymentListModel : PageModel
  {  
    private IdentityContext _context;
    public PaymentListModel(IdentityContext context , PaymentList paymentlistService)
    {
            _context=context;
            PaymentList = paymentlistService;

    }
    public PaymentList? PaymentList { get; set; }
    public void OnGet()
    {

    }
    public IActionResult OnPost(int GameId)
    {
        var game = _context.Games.FirstOrDefault(i=>i.GameId == GameId);
        if (game != null)
        {
            PaymentList?.Add(game,1);
        }
        return RedirectToPage("/paymentlist");


    }
    public IActionResult OnPostRemove(int GameId)
    {
      PaymentList?.RemoveItem(PaymentList.Items.First(i=>i.Game.GameId == GameId).Game);
      
      return RedirectToPage("/PaymentList");
    }

  }
}