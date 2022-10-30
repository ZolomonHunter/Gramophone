using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gramophone.Models
{
    [Table("Actors")]
    public class Actor : IdentityUser
    {
        public List<Playlist>? Playlists { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string? Label { get; set; }
        public List<Composition> Compositions { get; set; }

        public void AddPlayList(Playlist pl)
        {
            Playlists.Add(pl);
        }

        public void ChangeLabel(string lb)
        {
            Label = lb;
        }
    }
}
