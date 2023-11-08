using Newtonsoft.Json;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    public class JsonParsingStrategy : IDataParsingStrategy
    {
        public WeatherData ParseData(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<WeatherData>(data);
            }
            catch
            {
                throw new Exception("Failed to parse from Json");
            }
        }
        public bool IsDataCompatible(string data)
        {
            return data.StartsWith("{") && data.EndsWith("}") || data.StartsWith("[") && data.EndsWith("]");
        }
    }
}
