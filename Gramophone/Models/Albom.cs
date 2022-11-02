using System.ComponentModel.DataAnnotations;

namespace Gramophone.Models
{
    public class Albom
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Actor Owner { get; set; }
        public List<Composition>? Compositions { get; set; }
        public string Cover { get; set; }
    }
}
