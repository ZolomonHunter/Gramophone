using Gramophone.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Gramophone.Models
{
    public class User: IUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Поле не может быть пустым")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string Password { get; set; }

        public void Auth()
        {

        }

        public void DeleteAccount()
        {

        }

        public void Logout()
        {

        }
    }
}
