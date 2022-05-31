namespace Recaptcha.Models
{
    public class CaptchaInfoModel
    {
        public string SiteKey { get; set; }
        public string PrivateKey { get; set; }
        public string VerifyUrl { get; set; }
        public decimal MinScore { get; set; }
    }
}
