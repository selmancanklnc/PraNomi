using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraNomi.Models.Login
{
    public class LoginApiResponseModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("errorMessages")]
        public List<string> ErrorMessages { get; set; }

        [JsonProperty("successMessages")]
        public List<string> SuccessMessages { get; set; }

        [JsonProperty("warningMessages")]
        public List<string> WarningMessages { get; set; }
    }

    public class Item
    {
        [JsonProperty("apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("apiSecret")]
        public string ApiSecret { get; set; }
    }
}
