using Gramophone.Models;

namespace Gramophone.Data
{
    public class CompositionsExample
    {
        // временная штука как будто мы берем композиции с бд
        // TODO delete this
        public List<Composition> Compositions { get; set; }
        public CompositionsExample()
        {
            Compositions = new List<Composition>();
            Composition comp1 = new Composition("Faded", "Alan Walker", new TimeSpan(0, 0, 30), 2015, "Pop", "images/play-now-music/faded.png", "music/Faded.mp3");
            Composition comp2 = new Composition("Stay", "The Kid LAROI", new TimeSpan(0, 0, 30), 2021, "Pop", "images/play-now-music/stay.png", "music/stay.mp3");
            Compositions.Add(comp1);
            Compositions.Add(comp2);
        }

    }
}
