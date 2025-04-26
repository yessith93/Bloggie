using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        [BindProperty]
    public Login LoginViewModel { get; set; }
        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string ReturnUrl) 
        {
            var signInResult = await _signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (signInResult.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl.Trim()))
                {
                    return LocalRedirect(ReturnUrl);
                }
                return RedirectToPage("../Index");
            }
            else
            {
                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Unable to login"
                };

                return Page();
            }
        }
    }
}
