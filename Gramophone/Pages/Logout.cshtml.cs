using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gramophone.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<UserApp> _signInManager;

        public LogoutModel(SignInManager<UserApp> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
