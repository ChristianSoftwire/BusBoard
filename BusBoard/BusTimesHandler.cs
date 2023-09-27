using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    public static class BusTimesHandler
    {
        private static readonly RestClient client;

        static BusTimesHandler()
        {
            client = new RestClient("https://api.tfl.gov.uk");
        }

        public static List<BusTimes> GetBusTimes(string busStopId)
        {
            var request = new RestRequest($"StopPoint/{busStopId}/Arrivals");
            var response = client.Get(request);

            return response.Content != null ? JsonConvert.DeserializeObject<List<BusTimes>>(response.Content) : null;
        }
    }
}