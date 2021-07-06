using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace AQAPI_display
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } 

        //initializes the API client in order to make calls to the AQ API
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            //ApiClient.BaseAddress = new Uri("https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com/v2/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
