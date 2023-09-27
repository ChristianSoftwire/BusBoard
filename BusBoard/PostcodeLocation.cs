using Newtonsoft.Json;

namespace BusBoard
{
    public class PostcodeLocation
    {
        [JsonProperty("longitude")] public double Longitude { get; set; }
        [JsonProperty("latitude")] public double Latitude { get; set; }
    }

    public class PostcodeResult
    {
        [JsonProperty("result")] public PostcodeLocation Result { get; set; }
    }
}