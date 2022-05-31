using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recaptcha.Interface;

namespace Recaptcha.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IRecaptchaValidator RecaptchaValidator;
        public IndexModel(IRecaptchaValidator recaptchaValidator)
        {
            RecaptchaValidator = recaptchaValidator;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostSubscribeNewsletter(string email,string password, string token)
        {
            if (!RecaptchaValidator.IsValid(token))
            {
                
                return BadRequest();
            }
           
            return Page();
        }

        public JsonResult OnGetRecaptchaVerify(string token)
        {
            return new JsonResult(RecaptchaValidator.IsValid(token));
        }
    }
}