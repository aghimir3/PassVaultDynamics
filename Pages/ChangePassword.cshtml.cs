using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.DirectoryServices.AccountManagement;

namespace PassDynamics.Pages
{
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string CurrentPassword { get; set; }
        [BindProperty]
        public string NewPassword { get; set; }
        [BindProperty]
        public string ConfirmNewPassword { get; set; }

        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (NewPassword != ConfirmNewPassword)
            {
                ErrorMessage = "New passwords do not match.";
                return Page();
            }

            try
            {
                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    using (var user = UserPrincipal.FindByIdentity(context, Username))
                    {
                        if (user == null)
                        {
                            ErrorMessage = "User not found.";
                            return Page();
                        }

                        user.ChangePassword(CurrentPassword, NewPassword);
                        user.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error changing password: {ex.Message}";
                return Page();
            }

            // Redirect to a confirmation page or display a success message
            return RedirectToPage("./PasswordChangeSuccess");
        }
    }
}
