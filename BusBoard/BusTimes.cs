using Newtonsoft.Json;

namespace BusBoard
{
    public class BusTimes
    {
        [JsonProperty("expectedArrival")] public string ExpectedArrival { get; set; }
        [JsonProperty("lineName")] public string LineName { get; set; }
        
    }
}