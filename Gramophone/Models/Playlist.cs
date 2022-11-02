using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("CreatedPlaylists")]
        public Listener Owner { get; set; }
        [InverseProperty("SubscribedPlaylists")]
        public List<Listener> Subscribers { get; set; }
        public List<Composition> Compositions { get; set; }
        public string Cover { get; set; }

    }
}
