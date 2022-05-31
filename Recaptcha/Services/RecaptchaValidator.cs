using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Recaptcha.Interface;
using Recaptcha.Models;
using System.Net;

namespace Recaptcha.Services
{
    public class RecaptchaValidator : IRecaptchaValidator
    {
        private CaptchaInfoModel _captchaInfoModel;
       
        public RecaptchaValidator(IOptions<CaptchaInfoModel> captchaInfoModel)
        {
            _captchaInfoModel = captchaInfoModel.Value;           
        }
        public bool IsValid(string token)
        {
            TokenResponse tokenResponse = new TokenResponse()
            {
                Success = false
            };

            using var client = new HttpClient();
            var response = client.GetStringAsync($@"{_captchaInfoModel.VerifyUrl}?secret={_captchaInfoModel.PrivateKey}&response={token}").Result;
            var responseCaptcha = JsonConvert.DeserializeObject<TokenResponse>(response);

            

            if (!responseCaptcha.Success || responseCaptcha.Score < _captchaInfoModel.MinScore)
            {
                return false;
            }
            return true;
        }
    }
}
