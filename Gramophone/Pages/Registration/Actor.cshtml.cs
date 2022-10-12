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
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Actor> _userManager;
        private readonly SignInManager<Actor> _signInManager;
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        [DataType(DataType.Password)]

        public string CheckPassword { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        
        [Display(Name = "Лейбл")]
        public string Label { get; set; }


        public ActorModel(ApplicationDbContext db, UserManager<Actor> userManager, SignInManager<Actor> signInManager)
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
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
            else
            { return Page(); }
            return RedirectToPage("/Index");
        }
    }
}
