﻿using WeatherMonitoringAndReportingService.Models;

namespace WeatherMonitoringAndReportingService.DataHandling.DataParsing
{
    public interface IDataParsingStrategy
    {
        WeatherData ParseData(string data);
        bool IsDataCompatible(string data);
    }
}
