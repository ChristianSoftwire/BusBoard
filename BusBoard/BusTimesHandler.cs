using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    public static class BusTimesHandler
    {
        private static readonly RestClient client;
        public static string busStopName;

        static BusTimesHandler()
        {
            client = new RestClient("https://api.tfl.gov.uk");
        }

        public static List<BusTimes> GetBusTimesBusStopId(string busStopId)
        {
            var request = new RestRequest($"StopPoint/{busStopId}/Arrivals");
            var response = client.Get(request);

            if (response.Content == null)
            {
                throw new Exception("We never expect response content to be empty");
            }

            return JsonConvert.DeserializeObject<List<BusTimes>>(response.Content);
        }

        public static List<BusTimes> GetBusTimesPostcode(string postcode)
        {
            var postcodeDetail = PostcodeHandler.GetPostcodeDetail(postcode);
            
            var request =
                new RestRequest($"/StopPoint?stopTypes=NaptanPublicBusCoachTram&lat={postcodeDetail.Latitude}&lon={postcodeDetail.Longitude}");
            var response = client.Get(request);

            if (response.Content == null)
            {
                throw new Exception("We never expect response content to be empty");
            }

            var busDetailsForGivenPostcode = JsonConvert.DeserializeObject<BusDetailRadiusRoot>(response.Content);

            return busDetailsForGivenPostcode.StopPoints
                .Take(2)
                .SelectMany(stopPoint => GetBusTimesBusStopId(stopPoint.NaptanId))
                .ToList();
        }
    }
}