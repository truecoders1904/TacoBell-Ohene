namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();


        public ITrackable Parse(string line)
        {
            // logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array
            var cells = line.Split(',');

            double lat;
            double longit;

            if (cells.Length < 3)
            {
                logger.LogError("Not enough info on line.");
                return null;
            }
            else if (!double.TryParse(cells[0], out lat) || !double.TryParse(cells[1], out longit) || cells[2].Length == 0)
            {
                logger.LogError("Invalid data.");
                return null;
            }

            else if (lat > 90)
            {
                logger.LogInfo("Latitude cannot be greater than 90.");
                return null;
            }
            else if (longit > 180)
            {
                logger.LogInfo("Longitude cannot be greater than 180.");
                return null;
            }

            TacoBell tacobell = new TacoBell();
            tacobell.Name = cells[2];
            Point point = new Point();
            point.Latitude = lat;
            point.Longitude = longit;
            tacobell.Location = point;
            return tacobell;

            // Do not fail if one record parsing fails, return null
            //return null; // TODO Implement
        }
    }
}