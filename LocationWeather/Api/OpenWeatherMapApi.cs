using OpenWeatherMap.repository;
using OpenWeatherMap.Util;
using RestSharp;

namespace OpenWeatherMap.Api
{
    public static class OpenWeatherMapApi
    {
        public static RestResponse<RootObject> GetWeatherInfo(string location) {
            var client = new RestClient(Constants.URL);
            var request = new RestRequest("/data/2.5/weather?q=" + location + "&APPID=" + Constants.APPID, Method.Get);
            request.AddHeader("User-Agent", "Nothing");
            var contributors = client.Execute<RootObject>(request);
            return contributors;
        }

                
        
    }
}