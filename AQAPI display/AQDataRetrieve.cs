using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace AQAPI_display
{
    public class AQDataRetrieve
    {
        static string urlbase = "https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com/v2/";
        //makes a call to the AQ API to retrieve the AQ data for a given city at midnight of a given date 
        public static async Task<MeasurementModel> AQMeasurement(string country, string city, DateTime date)
        {
            string urlpart2 = "measurements?date_from=2000-01-01T00%3A00%3A00%2B00%3A00&date_to=";
            string urlpart3 = "T00%3A00%3A00%2B00%3A00&limit=1&page=1&offset=0&sort=desc&radius=1000&";
            string urlpart4 = "&order_by=datetime";
            string chosenDate = date.ToString("yyyy-MM-dd");

            string url = urlbase + urlpart2 + chosenDate + urlpart3 + "country_id=" + country + "&city=" + city + urlpart4;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AQResultsModel result = await response.Content.ReadAsAsync<AQResultsModel>();
                    
                    return result.Results[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        //makes a call to the AQ API to retrieve the average AQ data for a given country throughout a given day
        public static async Task<AverageAQModel> AverageAQ(string country, DateTime date) 
        {
            string urlpart2 = "averages?date_from=2000-01-01T00%3A00%3A00%2B00%3A00&date_to=";
            string urlpart3 = "T00%3A00%3A00%2B00%3A00&country_id=";
            string urlpart4 = "&limit=1&page=1&offset=0&sort=desc&spatial=country&temporal=day&group=false";
            string chosenDate = date.ToString("yyyy-MM-dd");

            string url = urlbase + urlpart2 + chosenDate + urlpart3 + country + urlpart4;


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AverageAQResultsModel result = await response.Content.ReadAsAsync<AverageAQResultsModel>();

                    return result.Results[0];
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
