using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NAudio.Wave;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Gramophone.Pages
{
    public class CreateAlbomModel : PageModel
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly string musicDirectory =  Path.Combine(Environment.CurrentDirectory, "wwwroot\\music");
        private readonly string imageDirectory = Path.Combine(Environment.CurrentDirectory, "wwwroot\\images\\alboms");
        [Required(ErrorMessage = "Пустое название альбома")]
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Загрузите треки")]
        public List<IFormFile> Files { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Загрузите обложку")]
        public IFormFile Cover { get; set; }


        public CreateAlbomModel(UserManager<UserApp> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> OnPost()
        {
            Albom albom = new Albom();
            albom.Name = Name;
            albom.Cover = "images/alboms/" + Cover.FileName;
            albom.Compositions = new List<Composition>();
            albom.Owner = _db.Actors.First();
            // TODO add owner as loggined user

            long size = Files.Sum(f => f.Length);
            foreach (var formFile in Files)
            {
                Composition composition = new Composition();
                composition.Audio = "music/" + formFile.FileName;
                composition.Cover = "images/alboms/" + Cover.FileName;
                // TODO все что снизу переделать нахуй
                composition.Year = 2022;
                composition.Genre = "zaebalo";
                composition.Actor = _db.Actors.First();
                composition.Author = composition.Actor.ToString();
                // TODO add actor as loggined user

                var filePath = Path.Combine(imageDirectory, Cover.FileName);
                using (var stream = System.IO.File.Create(filePath))
                    await formFile.CopyToAsync(stream);

                filePath = Path.Combine(musicDirectory, formFile.FileName);
                composition.Name = Path.GetFileNameWithoutExtension(filePath);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }

                Mp3FileReader reader = new Mp3FileReader(filePath);
                composition.Duration = reader.TotalTime;

                albom.Compositions.Add(composition);

            }
            _db.Add(albom);
            await _db.SaveChangesAsync();
            return Page();
        }

        public void OnGet()
        {
        }
    }
}
