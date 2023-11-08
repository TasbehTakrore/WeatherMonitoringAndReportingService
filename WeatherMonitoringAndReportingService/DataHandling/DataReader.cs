namespace WeatherMonitoringAndReportingService.DataHandling
{
    public class DataReader : IDataReader
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
