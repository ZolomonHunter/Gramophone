using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gramophone.Pages
{
    [BindProperties]
    public class LoginModel : PageModel
    {

        private readonly SignInManager<UserApp> _signInManager;
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        public LoginModel(SignInManager<UserApp> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Name, Password, true, false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError("Password", "Неправильный логин или пароль");
                    return Page();
                }
            }
            else
            { return Page(); }
        }
        public void OnGet()
        {
        }
    }
}
