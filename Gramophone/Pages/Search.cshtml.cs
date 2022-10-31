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
        public string? SearchString { get; set; }
        public List<Composition>? Compositions { get; set; }

        public async Task OnGetAsync()
        {
            CompositionsExample temp = new CompositionsExample();
            Compositions = temp.Compositions;
        }

        public void OnPost()
        {
        }
    }
}
