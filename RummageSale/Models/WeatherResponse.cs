using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RummageSale.Models
{
    public class WeatherResponse
    {
        public string City { get; set; }
        public string Weather { get; set; }
        public string Country { get; set; }
        public double Temp { get; set; }
        public double Temp_min { get; set; }
        public double Temp_max { get; set; }
    }
}
