using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Gramophone.Pages.Registration
{
    [BindProperties]
    public class ActorModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$", ErrorMessage = "Некорректный формат почты")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [RegularExpression("[0-9а-яА-яa-zA-Z!@#$%^&*]{8,}", ErrorMessage = "Недопустимые символы пароля")]
        [MinLength(8, ErrorMessage = "Пароль должен содержать минимум 8 символов")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]

        public string CheckPassword { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        
        [Display(Name = "Лейбл")]
        public string Label { get; set; }


        public ActorModel(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Actor actor = new Actor();
                actor.UserName = Name;
                actor.Email = Email;
                actor.Label = Label;
                var result = await _userManager.CreateAsync(actor, Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(actor, false);
                    return RedirectToPage("/Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }
            else
            { return Page(); }
        }
    }
}
