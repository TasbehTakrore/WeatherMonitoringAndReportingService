
using System.Text;
using System.Xml.Serialization;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    public class XmlParsingStrategy : IDataParsingStrategy
    {
        public WeatherData ParseData(string data)
        {
            try
            {
                using (MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(WeatherData));
                    WeatherData resultingMessage = serializer.Deserialize(memStream) as WeatherData;
                    return resultingMessage;
                }
            }
            catch
            {
                throw new Exception("Failed to parse from XML");
            }
        }
        public bool IsDataCompatible(string data)
        {
            return data.StartsWith("<") && data.EndsWith(">");
        }
    }
}
