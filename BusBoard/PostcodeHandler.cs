using System;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    public class PostcodeHandler
    {
        private static readonly RestClient client;

        static PostcodeHandler()
        {
            client = new RestClient("https://api.postcodes.io");
        }

        public static PostcodeLocation GetPostcodeDetail(string postcode)
        {
            var request = new RestRequest($"postcodes/{postcode}");
            var response = client.Get(request);

            return response.Content != null
                ? JsonConvert.DeserializeObject<PostcodeResult>(response.Content).Result
                : null;
        }
    }
}