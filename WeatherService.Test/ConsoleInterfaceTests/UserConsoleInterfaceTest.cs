using AutoFixture.Xunit2;
using Moq;
using WeatherMonitoringAndReportingService.ConsoleInterface;
using WeatherMonitoringAndReportingService.DataHandling;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.Models;
using WeatherMonitoringAndReportingService.WeatherReportPublishing;

namespace WeatherService.Test.ConsoleInterfaceTests
{

    public class UserConsoleInterfaceTest
    {
        [Theory]
        [AutoMoqData]
        public async Task Start_Should_InvokeThreeMethodsAsync(
            string rawData,
            WeatherData weatherData,
            [Frozen] Mock<IDataReader> mockDataReader,
            [Frozen] Mock<IDataParser> mockDataParser,
            [Frozen] Mock<IWeatherReportPublisher> mockWeatherReportPublisher,
            UserConsoleInterface sut)
        {
            //Arrange
            mockDataReader.Setup(dataReader => dataReader.ReadRawData()).Returns(rawData);
            mockDataParser.Setup(dataParser => dataParser.ParseData(rawData))
                .Returns(weatherData);

            //Act
            var cancellationTokenSource = new CancellationTokenSource();
            var delayTask = Task.Delay(TimeSpan.FromMilliseconds(100), cancellationTokenSource.Token);

            // Act
            _ = Task.Run(() =>
            {
                sut.Start();
                cancellationTokenSource.Cancel();
            });
            await delayTask;

            //Assert
            mockDataReader.Verify(x => x.ReadRawData());
            mockDataParser.Verify(x => x.ParseData(rawData));
            mockWeatherReportPublisher.Verify(x => x.PublishData(weatherData));
        }
    }
}
