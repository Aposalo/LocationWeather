using LocationWeather.Api;
using RestSharp;

namespace LocationWeather.Repositories
{
    public class OpenWeatherMapRepository
    {
        public RestResponse<RootObject> GetWeatherInfo(string location) => OpenWeatherMapApi.GetWeatherInfo(location);
    }
}