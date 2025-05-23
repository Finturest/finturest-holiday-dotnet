﻿using System.Globalization;

using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.IntegrationTests;

public partial class HolidayServiceClientIntegrationTests
{
    [Theory]
    [InlineData("2025-01-01", null)]
    [InlineData("2025-01-01", HolidayType.Public)]
    public async Task GetHolidaysByDateAsync_HolidaysExist_ReturnCorrectResult(string inputDate, HolidayType? type)
    {
        // Arrange
#if NET6_0_OR_GREATER
        var holidayDate = DateOnly.Parse(inputDate, CultureInfo.InvariantCulture);
#else
        var holidayDate = DateTime.Parse(inputDate, CultureInfo.InvariantCulture);
#endif

        // Act
        var result = await _sut.GetHolidaysAsync(holidayDate, type);

        // Assert
        result.ShouldNotBeEmpty();

        foreach (var holiday in result)
        {
            holiday.Name.ShouldNotBeNullOrEmpty();
            holiday.LocalName.ShouldNotBeNullOrEmpty();

            holiday.Country.ShouldNotBeNull();

            holiday.Country.Name.ShouldNotBeNullOrEmpty();
            holiday.Country.LocalName.ShouldNotBeNullOrEmpty();
            holiday.Country.Alpha2Code.ShouldNotBeNullOrEmpty();
            holiday.Country.Alpha3Code.ShouldNotBeNullOrEmpty();
            holiday.Country.NumericCode.ShouldNotBeNullOrEmpty();

            holiday.Types.ShouldNotBeEmpty();
        }
    }
}
