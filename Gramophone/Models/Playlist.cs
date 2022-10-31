using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Gramophone.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Listener> Users { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Composition> Compositions { get; set; }

    }
}
