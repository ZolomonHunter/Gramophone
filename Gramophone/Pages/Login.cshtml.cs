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
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [Display(Name = "��� ������������")]
        public string Name { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
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
                    ModelState.AddModelError("Password", "������������ ����� ��� ������");
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
