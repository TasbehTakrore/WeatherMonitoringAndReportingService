

namespace WeatherMonitoringAndReportingService.DataHandling
{
    internal class DataReader
    {
        public string ReadRawData()
        {
            string data;
            do
            {
                data = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(data));
            return data;
        }
    }
}
