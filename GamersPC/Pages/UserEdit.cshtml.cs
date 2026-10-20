using efcoreApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class UserEditModel : PageModel
{
    private readonly UserManager<User> _userManager;

    public UserEditModel(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    [Required]
    public string? FullName { get; set; }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [BindProperty]
    public string? NickName {get; set;}
    [BindProperty]
    public string? PhoneNumber {get; set;}

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login");
        }

        FullName = user.FullName;
        Email = user.UserEmail;
        NickName = user.UserNickname;
        PhoneNumber = user.UserPhoneNo;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToPage("/Account/Login");
        }

        user.FullName = FullName;
        user.UserEmail = Email;
        user.UserNickname = NickName;
        user.UserPhoneNo = PhoneNumber;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        return RedirectToPage("/UserProfile");
    }
}