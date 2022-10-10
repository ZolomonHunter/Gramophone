using System.ComponentModel.DataAnnotations;

namespace Gramophone.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не может быть пустым")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Password { get; set; }

        
    }
}
