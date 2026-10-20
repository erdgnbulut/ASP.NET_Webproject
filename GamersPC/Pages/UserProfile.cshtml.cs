using efcoreApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class UserProfileModel : PageModel
{
    private readonly UserManager<User> _userManager;
    private readonly IdentityContext _context;

    public UserProfileModel(UserManager<User> userManager, IdentityContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public User CurrentUser { get; set; } = null!;
    public List<UserGame> UserGames { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login");
        }

        CurrentUser = user;

        UserGames = await _context.UserGames
            .Include(ug => ug.Game)
            .Where(ug => ug.UserId == user.Id)
            .ToListAsync();

        return Page();
    }
    
}