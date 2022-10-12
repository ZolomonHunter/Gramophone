using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    [Table("Listeners")]
    public class Listener : IdentityUser
    {
        [Key]
        public List<Playlist>? Playlist { get; set; }
    }
}
