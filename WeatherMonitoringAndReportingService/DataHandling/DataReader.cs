namespace WeatherMonitoringAndReportingService.DataHandling
{
    public class DataReader
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
