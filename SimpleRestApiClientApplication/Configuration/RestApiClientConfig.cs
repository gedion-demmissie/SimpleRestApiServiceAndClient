using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleRestApiClientApplication.Configuration
{
    [JsonObject("RestApiClient")]
    public class RestApiClientConfig
    {
        [JsonProperty("EndPointUrl")]
        public string EndPointUrl { get; set; }

        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("UserAgent")]
        public string UserAgent { get; set; }
      
    }
}
