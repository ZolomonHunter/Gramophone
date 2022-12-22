using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gramophone.Models
{
    [Table("UserApp")]
    public class UserApp : IdentityUser
    {
        public string? NickName { get; set; }
        public bool? Sex { get; set; }
        public string? BirthDay { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ConfirmedQuestion { get; set; }
        public string? Cover { get; set; }
        public string? SecondEmail { get; set; }
        public string? QuestionResponse { get; set; }
    }
}
