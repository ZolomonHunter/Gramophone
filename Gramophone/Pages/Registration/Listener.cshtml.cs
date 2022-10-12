using Gramophone.Data;
using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gramophone.Pages.Registration
{
    [BindProperties]
    public class ListenerModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Listener> _userManager;
        private readonly SignInManager<Listener> _signInManager;
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [Display(Name = "��� ������������")]
        public string Name { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "����������� �����")]
        public string Email { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [MinLength(8, ErrorMessage = "������ ������ ��������� ������� 8 ��������")]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [Compare("Password", ErrorMessage = "������ �� ���������")]
        [DataType(DataType.Password)]
        [Display(Name = "������������� ������")]

        public string CheckPassword { get; set; }


        public ListenerModel(ApplicationDbContext db, UserManager<Listener> userManager, SignInManager<Listener> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Listener listener = new Listener();
                listener.UserName = Name;
                listener.Email = Email;
                var result = await _userManager.CreateAsync(listener, Password);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
            else
            { return Page(); }
            return RedirectToPage("/Index");
        }
    }
}
