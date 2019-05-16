using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            //logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            TacoBell tacoBell = new TacoBell();
            tacoBell.Location = new Point() { Latitude = 0, Longitude = 0 };


            ITrackable locationOne = null;
            ITrackable locationTwo = null;

            double maxDistance = 0;
            for (int i = 0; i < locations.Length; i++)
            {
                GeoCoordinate corA = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                for (int j = i + 1; j < locations.Length; j++)
                {
                    GeoCoordinate corB = new GeoCoordinate(locations[j].Location.Latitude, locations[j].Location.Longitude);
                    //maxDistance = corA.GetDistanceTo(corB);

                    if (corA.GetDistanceTo(corB) > maxDistance)
                    {
                        maxDistance = corA.GetDistanceTo(corB);
                        locationOne = locations[i];
                        locationTwo = locations[j];
                    }
                }
            }
            Console.WriteLine(locationOne.Name + " " + locationTwo.Name);


            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops

        }
    }
}
