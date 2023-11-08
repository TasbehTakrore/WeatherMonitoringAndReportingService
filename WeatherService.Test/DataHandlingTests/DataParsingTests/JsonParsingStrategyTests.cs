using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherService.Test.DataHandlingTests.DataParsingTests
{
    public class JsonParsingStrategyTests
    {
        [Theory]
        [InlineAutoData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}",
            "City Name", 32, 40)]
        public void ParseData_Should_ReturnWeatherData(
            string data, string expectedLocation, int expectedTemperature, int expectedHumidity, JsonParsingStrategy sut)
        {
            // Act
            WeatherData weatherData = sut.ParseData(data);

            // Assert
            weatherData.Location.Should().Be(expectedLocation);
            weatherData.Temperature.Should().Be(expectedTemperature);
            weatherData.Humidity.Should().Be(expectedHumidity);
        }

        [Theory]
        [AutoData]
        public void ParseData_Should_ThrowException_WhenParsingFailed(JsonParsingStrategy sut)
        {
            // Act and Assert
            Action act = () => sut.ParseData(It.IsAny<string>());
            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineAutoData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}")]
        public void IsDataCompatible_Should_ReturnTrue(string data, JsonParsingStrategy sut)
        {
            //Act
            var isDataCompatible = sut.IsDataCompatible(data);

            //Assert
            isDataCompatible.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public void IsDataCompatible_Should_ReturnFalse(JsonParsingStrategy sut)
        {
            //Act
            var isDataCompatible = sut.IsDataCompatible("");

            //Assert
            isDataCompatible.Should().BeFalse();
        }
    }
}
