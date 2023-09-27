using System.Collections.Generic;

namespace BusBoard
{
    public class StopPoint
    {
        public string NaptanId { get; set; }
    }

    public class BusDetailRadiusRoot
    {
        public List<StopPoint> StopPoints { get; set; }
    }
    
    
}