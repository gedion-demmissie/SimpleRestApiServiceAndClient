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
        private static IConfigurationBuilder builder = new ConfigurationBuilder()
                                                          .SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                                          .AddEnvironmentVariables();
        static  void  Main(string[] args)
        {
            var restApiClientConfig = new RestApiClientConfig();
            builder.Build().GetSection("RestApiClient").Bind(restApiClientConfig);

            var dateTimeServedContent =  RestApiClient<DateTimeResponsePayload>.Get(url:restApiClientConfig.EndPointUrl, contentType:restApiClientConfig.ContentType , userAgent:restApiClientConfig.UserAgent).Result;  
           
            Console.WriteLine($"The served content time from the Rest api is: {dateTimeServedContent.CurrentDateTimeFromServer}.");               
            Console.WriteLine();
            Console.ReadKey();
        }       
    }
}
