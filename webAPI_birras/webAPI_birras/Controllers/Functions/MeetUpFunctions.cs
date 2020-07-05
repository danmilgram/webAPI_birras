using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI_birras.Controllers.Functions
{
    public class MeetUpFunctions
    {
        public int CalculateBeers(int guests, double avgTemp )
        {
            double beers = 0;

            if (avgTemp < 20)
            {
                beers = guests * 0.75;
            }
            else if (avgTemp > 20 & avgTemp < 24)
            {
                beers = guests;
            }
            else if (avgTemp > 24)
            {
                beers = guests * 3;
            }

            int cajones = Convert.ToInt32(Math.Ceiling(beers / 6));
            return cajones;             
        }
    }
}
