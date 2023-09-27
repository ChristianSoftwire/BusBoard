using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("How do you want to look for buses ");
                var choseStopcode = Console.ReadLine()?.ToLower() == "stopcode";

                Console.Write(choseStopcode
                    ? "Enter the id of the bus stop you wish to check for "
                    : "Enter your nearest postcode ");
                
                var input = Console.ReadLine();
                var busTimes = choseStopcode
                    ? BusTimesHandler.GetBusTimesBusStopId(input)
                    : BusTimesHandler.GetBusTimesPostcode(input);
                PrintNextBuses(busTimes);
            }
        }

        private static void PrintNextBuses(IEnumerable<BusTimes> busTimes)
        {
            foreach (var bus in busTimes)
            {
                var time = bus.ExpectedArrival.ToShortTimeString();
                Console.WriteLine($"Bus {bus.LineName} will be arriving at {bus.StationName} at {time}");
            }
        }
    }
}