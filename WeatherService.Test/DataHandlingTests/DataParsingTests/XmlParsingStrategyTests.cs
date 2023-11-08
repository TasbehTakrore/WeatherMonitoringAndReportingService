using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using WeatherMonitoringAndReportingService.DataHandling.DataParsing;
using WeatherMonitoringAndReportingService.Models;

namespace WeatherService.Test.DataHandlingTests.DataParsingTests
{
    public class XmlParsingStrategyTests
    {
        [Theory]
        [InlineAutoData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>",
          "City Name", 32, 40)]
        public void ParseData_Should_ReturnWeatherData(
          string data, string expectedLocation, int expectedTemperature, int expectedHumidity, XmlParsingStrategy sut)
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
        public void ParseData_Should_ThrowException_WhenParsingFailed(XmlParsingStrategy sut)
        {
            // Act and Assert
            Action act = () => sut.ParseData(It.IsAny<string>());
            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineAutoData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
        public void IsDataCompatible_Should_ReturnTrue(string data, XmlParsingStrategy sut)
        {
            //Act
            var isDataCompatible = sut.IsDataCompatible(data);

            //Assert
            isDataCompatible.Should().BeTrue();
        }

        [Theory]
        [AutoData]
        public void IsDataCompatible_Should_ReturnFalse(XmlParsingStrategy sut)
        {
            //Act
            var isDataCompatible = sut.IsDataCompatible("");

            //Assert
            isDataCompatible.Should().BeFalse();
        }
    }
}
