using OpenWeatherMap.Api;
using RestSharp;

namespace OpenWeatherMap.repository
{
    public class OpenWeatherMapRepository
    {
        public RestResponse<RootObject> GetWeatherInfo(string location) => OpenWeatherMapApi.GetWeatherInfo(location);
    }
}