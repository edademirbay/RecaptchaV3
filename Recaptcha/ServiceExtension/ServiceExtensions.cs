using Recaptcha.Interface;
using Recaptcha.Models;
using Recaptcha.Services;

namespace Recaptcha.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static void RegisterRepos(this IServiceCollection collection)
        {
            collection.AddSingleton<IRecaptchaValidator, RecaptchaValidator>();           

        }
    }
}
