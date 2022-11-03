using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NAudio.Wave;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gramophone.Pages
{
    [BindProperties(SupportsGet = true)]
    public class CreatePlaylistModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly string musicDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot\\music");

        [Required(ErrorMessage = "Пустое название плейлиста")]
        [BindProperty]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пустое описание плейлиста")]
        [BindProperty]
        public string Description { get; set; }
        public string? SearchString { get; set; }
        public CreatePlaylistModel(UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
            AddedCompositions = new List<Composition>();
        }
        public List<Composition>? Compositions { get; set; }
        public List<Composition>? AddedCompositions { get; set; }

        public async Task OnGetAsync()
        {
            // TODO take from db and sort here instead in view
            if (String.IsNullOrEmpty(SearchString))
                Compositions = _db.Compositions.ToList();
            else
            {
                Compositions = _db.Compositions.ToList().Where(
                (p => p.Name.ToLower().Contains(SearchString.ToLower()) || p.Author.ToLower().Contains(SearchString.ToLower())
                )).ToList();
            }
        }

       public void AddToList(Composition c)
        {
            AddedCompositions.Add(c);
        }
        //public async Task<IActionResult> OnPost()
        //{
        //    Albom albom = new Albom();
        //    albom.Name = Name;
        //    albom.Cover = "images/alboms/" + Cover.FileName;
        //    albom.Compositions = new List<Composition>();
        //    albom.Owner = _db.Actors.First();
        //    // TODO add owner as loggined user

        //    long size = Files.Sum(f => f.Length);
        //    foreach (var formFile in Files)
        //    {
        //        Composition composition = new Composition();
        //        composition.Name = formFile.Name;
        //        composition.Audio = "music/" + formFile.FileName;
        //        composition.Cover = "images/alboms/" + Cover.FileName;
        //        // TODO все что снизу переделать нахуй
        //        composition.Year = 2022;
        //        composition.Genre = "zaebalo";
        //        composition.Actor = _db.Actors.First();
        //        composition.Author = composition.Actor.ToString();
        //        // TODO add actor as loggined user

        //        var filePath = Path.Combine(imageDirectory, Cover.FileName);

        //        using (var stream = System.IO.File.Create(filePath))
        //            await formFile.CopyToAsync(stream);

        //        if (formFile.Length > 0)
        //        {
        //            filePath = Path.Combine(musicDirectory, formFile.FileName);

        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //            Mp3FileReader reader = new Mp3FileReader(filePath);
        //            composition.Duration = reader.TotalTime;
        //        }
        //        albom.Compositions.Add(composition);

        //    }
        //    _db.Add(albom);
        //    await _db.SaveChangesAsync();
        //    return Page();
        //}
        public void OnPost()
        {
        }
    }
}
