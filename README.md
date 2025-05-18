# Finturest Holiday API C# SDK

[![NuGet](https://img.shields.io/nuget/v/Finturest.Holiday.svg)](https://www.nuget.org/packages/Finturest.Holiday)
![CI](https://github.com/finturest/finturest-holiday-dotnet/actions/workflows/ci.yml/badge.svg)

Official C# SDK for the [Finturest Holiday API](https://finturest.com/products/holiday-api) - supports .NET Standard 2.0+ and all modern .NET versions.

## Overview

This SDK provides a convenient and efficient way to access the Finturest Holiday API in your .NET applications. It supports .NET Standard 2.0 and later, ensuring compatibility with .NET Core and the latest .NET releases.

## Features

- **Worldwide Holiday Coverage**: Access public, national, bank, and regional holidays across 250+ countries and territories.

- **Multi-Year Range**: Query holidays for any year or range of years — past, current, or future.

- **Region & Subdivision Support**: Retrieve holidays based on country, region, state, or province with ISO-compliant codes.

- **Date-Based Lookups**: Check if a specific date is a holiday, weekend, or working day in a given location.

- **Flexible Filters**: Filter holidays by type (public, religious, observance), and country.

- **Official Sources**: Data is aggregated from government declarations and official sources for accuracy and reliability.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://learn.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package Finturest.Holiday
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install Finturest.Holiday
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Finturest.Holiday
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Finturest.Holiday".
5. Click on the Finturest.Holiday package, select the appropriate version in the
   right-tab and click _Install_.

## Usage

### Registering

To use the `Finturest.Holiday` client, register it in your application's dependency injection container using `AddFinturestHoliday`. This configures the services required to communicate with the Finturest Holiday API.

```C#
var services = new ServiceCollection();

services.AddFinturestHoliday(options =>
{
    options.ApiKey = "YOUR_API_KEY";
});
```

> **Note**  
> `IHolidayServiceClient` is registered in the DI container and should be resolved via dependency injection.  
> In ASP.NET Core applications, it's recommended to inject it through constructor injection.

> **Note**  
> The abstractions for the Finturest Holiday API client are provided in a separate package named `Finturest.Holiday.Abstractions`.  
> You can reference this package in your business layer to avoid a tight dependency on the implementation.  
> Only the root application or composition root should reference the full `Finturest.Holiday` package that contains the implementation.

### Get upcoming holidays

To get upcoming holidays using the Finturest Holiday API, call the `GetUpcomingHolidaysAsync` method on the `IHolidayServiceClient`.

```C#
var serviceProvider = services.BuildServiceProvider();

var holidayServiceClient = serviceProvider.GetRequiredService<IHolidayServiceClient>();

var result = await holidayServiceClient.GetUpcomingHolidaysAsync(countryCode: "PL", days: 365, type: HolidayType.Public);

Console.WriteLine($"Holidays: {result.Count}.");
```

> **Note**  
> In production applications, avoid using `BuildServiceProvider()` manually.  
> Instead, use constructor injection to get `IHolidayServiceClient` from the framework’s dependency injection system.

## Subscription & Pricing

To get access to the Finturest Holiday API or subscribe to a plan, please visit the subscription page. An active subscription is required to access the API in production.

[Manage subscriptions](https://finturest.com/dashboard/subscriptions)

## API Key Generation

An API key is required to use the SDK and can be generated on your Finturest dashboard:

[Generate API key](https://finturest.com/dashboard/access-tokens)

## Documentation

For full API reference and usage guides, please visit the official Finturest Holiday API documentation:

[View API reference](https://api.finturest.com/docs/#tag/holiday)

## Contact

For support, questions, or inquiries, please contact us at: [support@finturest.com](mailto:support@finturest.com)
