using System.ComponentModel.DataAnnotations;

namespace Gramophone.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public List<Listener> Users { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
