using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gramophone.Pages.Registration
{
    public class ListenerModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Listener Listener { get; set; }
        public string CheckPassword { get; set; }

        public ListenerModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Listener.Password != CheckPassword)
                ModelState.AddModelError("CheckPassword", "������ �� ���������");
            if (ModelState.IsValid)
            {
                await _db.Users.AddAsync(Listener);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();            
        }
    }
}