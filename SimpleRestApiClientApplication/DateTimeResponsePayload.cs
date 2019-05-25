using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;

namespace SimpleRestApiClientApplication
{
   
   
    [DataContract(Name = "DateTimeContent")]
    public class DateTimeResponsePayload
    {
        [DataMember(Name = "currentDateTime")]
        private string JsonDate { get; set; }

        //The supported datetime formats as an array
        [IgnoreDataMember]
        private static string[] dateFormats = {
                               "yyyy-MM-ddTHH:mm:ssZ",
                               "yyyy-MM-ddTHH:mm:ss.ffffffzzz",
                               "yyyy-MM-ddTHH:mm:ss.fffffffzzz",
                               "yyyy-MM-ddThh:mm:ss tt",
                               "yyyy-MM-ddTh:mm:ss tt",
                               "yyyy-MM-ddTh:m:ss tt",
                               "yyyy-MM-ddTHH:mm:ss",
                               "yyyy-MM-ddTH:mm:ss",
                               "yyyy-MM-ddTH:m:ss",
                               "yyyy-MM-ddThh:mm:ss tt",
                               "yyyy-MM-ddTh:mm:ss tt",
                               "yyyy-MM-ddTh:m:ss tt",
                               "yyyy-MM-ddTHH:mm:ss",
                               "yyyy-MM-ddTH:mm:ss",
                               "yyyy-MM-ddTH:m:ss"
                     };

        [IgnoreDataMember]
        public DateTime CurrentDateTimeFromServer
        {
            get
            {
                return DateTime.ParseExact(JsonDate, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
        }
    }
}

