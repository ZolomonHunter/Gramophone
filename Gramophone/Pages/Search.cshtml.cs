using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gramophone.Pages
{
    public class SearchModel : PageModel
    {
        public string SearchString { get; set; }
        public void OnGet()
        {
        }
    }
}
