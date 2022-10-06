using LocationWeather.Repositories;
using LocationWeather.Utils;
using RestSharp;

namespace LocationWeather.Api
{
    public static class OpenWeatherMapApi
    {
        private readonly static RestClient restClient = new RestClient(Constants.URL);

        public static RestResponse<RootObject> GetWeatherInfo(string location) {
            
            var query = Constants.QUERY_LOCATION + location + Constants.QUERY_TOKEN + Constants.TOKEN;
            var request = new RestRequest(query);
            request.AddHeader(Constants.REQUEST_HEADER_NAME, Constants.REQUEST_HEADER_VALUE);
            
            var contributors = restClient.Execute<RootObject>(request);
            return contributors;
        }
    }
}