using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gramophone.Models
{
    [Table("Actors")]
    public class Actor : User
    {
        [Key]
        public List<Playlist>? Playlists { get; set; }

        public string? Label { get; set; }

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
