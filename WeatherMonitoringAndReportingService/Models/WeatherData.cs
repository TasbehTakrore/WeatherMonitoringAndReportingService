using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherMonitoringAndReportingService.Models
{
    public class WeatherData
    {
        public string Location { get; set; }
        public double Humidity { get; set; }
        public double Temperature { get; set; }
    }
}
