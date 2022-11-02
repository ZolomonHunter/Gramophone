using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Gramophone.Pages
{
    [BindProperties(SupportsGet = true)]
    public class SearchModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public string? SearchString { get; set; }
        public List<Composition>? Compositions { get; set; }
        public SearchModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGetAsync()
        {
            // TODO take from db and sort here instead in view
            if (String.IsNullOrEmpty(SearchString))
                Compositions = _db.Compositions.ToList();
            else{
                Compositions = _db.Compositions.ToList().Where(
                (p => p.Name.ToLower().Contains(SearchString.ToLower()) || p.Author.ToLower().Contains(SearchString.ToLower())
                )).ToList();
            }
        }

        public void OnPost()
        {
        }
    }
}
