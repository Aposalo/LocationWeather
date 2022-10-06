using OpenWeatherMap.repository;
using OpenWeatherMap.Util;
using RestSharp;

namespace OpenWeatherMap.Api
{
    public static class OpenWeatherMapApi
    {
        private static RestClient restClient = new RestClient(Constants.URL);

        public static RestResponse<RootObject> GetWeatherInfo(string location) {
            
            var requestQuery = Constants.QUERY_LOCATION + location + Constants.QUERY_TOKEN + Constants.TOKEN;
            var request = new RestRequest(requestQuery);
            request.AddHeader(Constants.REQUEST_HEADER_NAME, Constants.REQUEST_HEADER_VALUE);
            
            var contributors = restClient.Execute<RootObject>(request);
            return contributors;
        }
    }
}