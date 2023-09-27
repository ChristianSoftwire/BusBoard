using System;
using Newtonsoft.Json;

namespace BusBoard
{
    public class BusTimes
    {
        [JsonProperty("expectedArrival")] public DateTime ExpectedArrival { get; set; }
        [JsonProperty("lineName")] public string LineName { get; set; }

        [JsonProperty("stationName")] public string StationName { get; set; }
    }
}