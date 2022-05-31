namespace Recaptcha.Interface
{
    public interface IRecaptchaValidator
    {
        bool IsValid(string token); 
    }
}
