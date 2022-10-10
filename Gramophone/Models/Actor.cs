using Microsoft.Data.SqlClient.DataClassification;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Gramophone.Models
{
    [Table("Actors")]
    public class Actor: User
    {
        [Key]
        public List<Playlist> _playlists;

        public Label _label;

        public void AddPlayList(Playlist pl)
        {
            _playlists.Add(pl);
        }

        public void ChangeLabel(Label lb)
        {
            _label = lb;
        }
    }
}
