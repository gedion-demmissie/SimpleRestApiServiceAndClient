using Microsoft.Extensions.Configuration;
using SimpleRestApiClientApplication.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace SimpleRestApiClientApplication
{
    /// <summary>
    /// Program to drive the SimpleRestApi service
    /// </summary>
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        private static IConfigurationBuilder builder = new ConfigurationBuilder()
                                                          .SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                          .AddEnvironmentVariables();
        static  void  Main(string[] args)
        {
            var dateTimeServedContent =  ProcessDateTimeResponsePayload().Result;           
            Console.WriteLine($"The served content time from the Rest api is: {dateTimeServedContent.CurrentDateTimeFromServer}.");               
            Console.WriteLine();
            Console.ReadKey();
        }

        private static async Task<DateTimeResponsePayload> ProcessDateTimeResponsePayload()
        {
            var serializer = new DataContractJsonSerializer(typeof(DateTimeResponsePayload));
            var restApiClientConfig = new RestApiClientConfig();
           
             builder.Build().GetSection("RestApiClient").Bind(restApiClientConfig);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(restApiClientConfig.ContentType));
            client.DefaultRequestHeaders.Add("User-Agent", restApiClientConfig.UserAgent);

            var streamTask = client.GetStreamAsync(restApiClientConfig.EndPointUrl);
            var dateTimeResponsePayload = serializer.ReadObject(await streamTask) as DateTimeResponsePayload;
            return dateTimeResponsePayload;
        }
       
    }
}
