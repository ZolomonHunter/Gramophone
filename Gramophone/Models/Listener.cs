using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    [Table("Listeners")]
    public class Listener : User
    {
        [Key]
        public List<Playlist> Playlist { get; set; }
    }
}
