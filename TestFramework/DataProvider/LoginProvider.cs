using Newtonsoft.Json;

namespace TestFramework.DataProvider
{
    public class LoginProvider
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; } = "939830540";
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = "Darina_1234";
        [JsonProperty(PropertyName = "verificationCode")]
        public string VerificationCode { get; } = "";
        [JsonProperty(PropertyName = "xClient")]
        public string XClient { get; } = "0a5a78f5d0538fc84955d1b5640af1d7";
    }
}
