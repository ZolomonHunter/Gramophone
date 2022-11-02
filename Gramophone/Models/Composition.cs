using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    public class Composition
    {
        public Composition()
        {
        }

        //TODO delete this and get comps from db
        public Composition(string name, string author, TimeSpan duration, int year, string genre, string cover, string audio)
        {
            Name = name;
            Author = author;
            Duration = duration;
            Year = year;
            Genre = genre;
            Cover = cover;
            Audio = audio;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Actor Actor { get; set; }
        [Column(TypeName = "bigint")]
        public TimeSpan Duration { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Audio { get; set; }
        public List<Playlist> InPlaylists { get; set; }
       

    }
}
