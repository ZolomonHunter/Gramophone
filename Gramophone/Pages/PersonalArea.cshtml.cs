using Gramophone.Data;
using Gramophone.Interfaces;
using Gramophone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Gramophone.Pages
{
    [BindProperties]
    public class PersonalAreaModel : PageModel
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<UserApp> _signInManager;

         
        [BindProperty]
        public string? Name { get; set; }
        [BindProperty]
        
        public string? FirstName { get; set; }
        [BindProperty]
        
        public string? LastName { get; set; }
        [BindProperty]
        public bool? Sex { get; set; }
        [BindProperty]
        public string? DOB { get; set; }
        [BindProperty]
        public string? PhoneNumber { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]

        public string? ConfirmedQuestion { get; set; }
        [BindProperty]

        public string? QuestionResponse { get; set; }
        [BindProperty]
        public string? SecondEmail { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Загрузите обложку")]
        public IFormFile Cover { get; set; }
        [BindProperty]
        public string? NewPassword { get; set; }
        [BindProperty]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }
        public PersonalAreaModel(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = await _userManager.GetUserNameAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Name = userName;
            DOB = user.BirthDay;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Sex = true;
            ConfirmedQuestion = user.ConfirmedQuestion;
            SecondEmail = user.SecondEmail;
            Email = email;
            PhoneNumber = phoneNumber;
            QuestionResponse = user.QuestionResponse;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            if (Name != null)
            {
                user.UserName = Name;
                user.Sex = Sex;
                user.LastName = LastName;
                user.FirstName = FirstName;
                user.BirthDay = DOB;
            }
            var email = await _userManager.GetEmailAsync(user);

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (PhoneNumber != phoneNumber && !String.IsNullOrEmpty(PhoneNumber))
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            if (Email != email && !String.IsNullOrEmpty(Email))
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            if (SecondEmail != email && !String.IsNullOrEmpty(SecondEmail))
            {
                user.SecondEmail = SecondEmail;
            }

            if (ConfirmedQuestion != String.Empty)
                user.ConfirmedQuestion = ConfirmedQuestion;
            if(QuestionResponse != String.Empty)
                user.QuestionResponse = QuestionResponse;

            if (OldPassword != null && NewPassword != null)
                await ChangePassword();
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);

            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (!String.IsNullOrEmpty(OldPassword) && !String.IsNullOrEmpty(NewPassword))
            {
                IdentityResult result =
                await _userManager.ChangePasswordAsync(user, OldPassword, NewPassword);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("Password", "Неправильный логин или пароль");
                    return Page();
                }
            }
            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            return RedirectToPage();
        }
    }
}
