using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RummageSale.Helpers
{
    public class OpenWeatherResponse
    {
       
            public List<Weather> Weather { get; set; }
            public Main Main { get; set; }
            public Sys Sys { get; set; }
            public string Name { get; set; }
        }

        public class Weather
        {
            public string Main { get; set; }
        }

        public class Main
        {
            public double Temp { get; set; }
            public double Temp_min { get; set; }
            public double Temp_max { get; set; }
        }

        public class Sys
        {
            public string Country { get; set; }
        }
    }
