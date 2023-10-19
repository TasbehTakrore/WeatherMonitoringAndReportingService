# Real-time Weather Monitoring and Reporting Service

[![.NET Version](https://img.shields.io/badge/.NET-7.0-blue)](https://dotnet.microsoft.com/)

## Table of Contents

- [Table of Contents](#Table-of-Contents)
- [Description](#description)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Application Structure and Design Patterns](#Application-Structure-and-Design-Patterns)
  - [Description](#description)
  - [Flow Chart](#Flow-Chart)
  - [Project Structure](#Project-Structure)
- [Contact](#Contact)


## Description

The Real-time Weather Monitoring and Reporting Service is a .NET console application developed for receiving and processing raw weather data in various formats (e.g., JSON, XML) from different weather stations serving various locations. This application features different types of 'weather bots,' each configured to react differently based on the incoming weather updates.

## Getting Started

### Prerequisites

Before you can use this weather monitoring and reporting service, you'll need to ensure the following prerequisites:

1. **.NET Core SDK**: Make sure you have the .NET Core SDK installed on your machine. (.NET 7.0 or later)

2. **Code Editor (Optional)**: You can use a code editor of your choice, such as Visual Studio or Visual Studio Code, for development.

3. **[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)** (Version 13.0.3).

4. **[Microsoft.Extensions.Configuration.Json](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/)** (Version 7.0.0).

5. **[Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/8.0.0-rc.2.23479.6)** (Version 7.0.4).


### Installation

To set up and run the Weather Monitoring and Reporting Service, follow these steps:

1. Clone the repository to your local machine:
      `git clone https://github.com/TasbehTakrore/WeatherMonitoringAndReportingService.git`

2. Navigate to the project directory:
`cd WeatherMonitoringAndReportingService`


3. Update the `appsettings.json` file as needed.

4. Build and Run the application.

## Usage

To use the Real-time Weather Monitoring and Reporting Service, follow these steps:

1. **Start the Application**
     - Run the application by executing the appropriate command from your command line or preferred development environment.

3. **Enter Weather Data**
    - The system will prompt you to enter weather data with the message: `Enter weather data:`
    - You can provide the weather data in either JSON or XML format. Here are examples of both formats:

    - JSON format:
      ```json
      {
        "Location": "City Name",
        "Temperature": 32,
        "Humidity": 40
      }
      ```

    - XML format:
      ```xml
      <WeatherData>
          <Location>City Name</Location>
          <Temperature>32</Temperature>
          <Humidity>40</Humidity>
      </WeatherData>
      ```

3. **Processing and Response**
    - The system will process the provided weather data and activate the relevant weather bots according to their configurations.
    - If a bot is enabled and its conditions are met, the system will respond with the bot's message. For example:
      
        ```vbnet
        SunBot activated!
        SunBot: "Wow, it's a scorcher out there!"
        ```


## Project Structure and Design Patterns

 ### Description
 
  This application is designed with a focus on modularity and maintainability. The Observer design pattern is utilized to allow multiple 'weather bots' to react to real-time data independently. Additionally, the Strategy design pattern is employed to parse different data formats seamlessly. This architecture ensures that adding new types of bots or supporting additional weather data formats can be achieved without significant changes to the existing codebase. The project structure is organized to make it easy to extend and adapt to future requirements.

### Flow Chart

![image](https://github.com/TasbehTakrore/WeatherMonitoringAndReportingService/assets/71009816/74968eba-1508-4b4e-8e1c-3d10847b0bfe)


### Project Structure

````
C:.
│   appsettings.json
│   BotSettingsReader.cs
│   Program.cs
│   Startup.cs
│   WeatherMonitoringAndReportingService.csproj
│
├───bin
│
├───BotFactory
│       IWeatherBotFactory.cs
│       WeatherBotFactory.cs
│
├───ConsoleInterface
│       IUserConsoleInterface.cs
│       UserConsoleInterface.cs
│
├───DataHandling
│   │   DataReader.cs
│   │
│   └───DataParsing
│           DataParserContext.cs
│           DataParsingStrategyFactory.cs
│           IDataParsingStrategy.cs
│           JsonParsingStrategy.cs
│           XmlParsingStrategy.cs
│
├───Models
│       BotSettings.cs
│       WeatherData.cs
│
├───obj
│
└───WeatherReportPublishing
        IWeatherObserver.cs
        IWeatherReportPublisher.cs
        RainBot.cs
        SnowBot.cs
        SunBot.cs
        WeatherReportPublisher.cs
````

## Contact

If you have any questions, feedback, or need assistance with the Real-time Weather Monitoring and Reporting Service, feel free to get in touch with us:

- **Email:** tasbeh.takrore@gmail.com
- **GitHub:** [Tasbeeh Takrori](https://github.com/TasbehTakrore)

I'm excited to see you using the Real-time Weather Monitoring and Reporting Service application. I look forward to hearing your feedback and suggestions to improve this project.
