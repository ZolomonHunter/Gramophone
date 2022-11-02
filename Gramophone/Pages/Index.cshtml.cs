using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Gramophone.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext db, ILogger<IndexModel> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async void OnGet()
        {
            // TODO эту хуйню убрать
            if (_db.Compositions.FirstOrDefault(p => p.Name == "Faded") == null)
            {
                Composition comp1 = new Composition("Faded", "Alan Walker", new TimeSpan(0, 0, 30), 2015, "Pop", "images/play-now-music/faded.png", "music/Faded.mp3");
                Composition comp2 = new Composition("Stay", "The Kid LAROI", new TimeSpan(0, 0, 30), 2021, "Pop", "images/play-now-music/stay.png", "music/stay.mp3");
                Composition comp3 = new Composition("Rather Be", "Clean Bandit", new TimeSpan(0, 0, 30), 2014, "Pop", "images/play-now-music/ratherbe.jpg", "music/Rather Be.mp3");
                _db.Compositions.Add(comp1);
                _db.Compositions.Add(comp2);
                _db.Compositions.Add(comp3);
                await _db.SaveChangesAsync();
            }
        }
    }
}