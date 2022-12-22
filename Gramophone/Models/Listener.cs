using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    [Table("Listeners")]
    public class Listener : UserApp
    {
        public List<Playlist>? CreatedPlaylists { get; set; }
        public List<Playlist>? SubscribedPlaylists { get; set; }
    }
}
