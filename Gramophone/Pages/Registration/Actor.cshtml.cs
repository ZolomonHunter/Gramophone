using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gramophone.Pages.Registration
{
    public class ActorModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Actor Actor { get; set; }
        [BindProperty]
        public string CheckPassword { get; set; }

        public ActorModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Actor.Password != CheckPassword)
                ModelState.AddModelError("CheckPassword", "Пароли не совпадают");
            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(Actor);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
