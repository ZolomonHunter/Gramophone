using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    public class Composition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Actor Actor { get; set; }
        public double Duration { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
        public string Audio { get; set; }

    }
}
