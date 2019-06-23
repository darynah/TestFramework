using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestFramework.DataProvider
{
    public class LoginProviderMonitor
    {
        [JsonProperty(PropertyName = "includeAttributes")]
        public string[] IncludeAttributes { get; set; } = new []{ "perm.*" };
        [JsonProperty(PropertyName = "userName")]
        public string Login { get; set; } = "admin@betlab";
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = "abc";
    }
}