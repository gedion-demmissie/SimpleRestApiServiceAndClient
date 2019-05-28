using Microsoft.Extensions.Configuration;
using SimpleRestApiClientApplication.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRestApiClientApplication
{
    public class RestApiClient<T>
    {
        private static readonly HttpClient client = new HttpClient();
     
         public static async Task<T> Get(string url,string contentType, string userAgent)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(contentType));
            client.DefaultRequestHeaders.Add("User-Agent", userAgent);

            var streamTask = client.GetStreamAsync(url);
            T responsePayload = (T)serializer.ReadObject(await streamTask);
            return responsePayload;

        }
    }
}
