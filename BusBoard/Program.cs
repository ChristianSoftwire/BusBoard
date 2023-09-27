using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the id of the bus stop you wish to check for ");
            var busStopId = Console.ReadLine();

            var busTimes = BusTimesHandler.GetBusTimes(busStopId);

            Console.WriteLine($"busTimes {busTimes}");
        }

        public static void PrintNextBuses(List<BusTimes> busTimes)
        {
            //iterate over and print each bus with the corresponding time
        }
    }
}