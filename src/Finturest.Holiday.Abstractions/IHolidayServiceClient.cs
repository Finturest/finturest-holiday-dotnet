using Finturest.Holiday.Abstractions.Models;
using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.Abstractions;

/// <summary>
/// Provides methods for sending requests to and receiving responses from the Finturest Holiday API.
/// </summary>
public interface IHolidayServiceClient
{
    /// <summary>
    /// Retrieves a list of upcoming holidays for the specified country.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "US", "DE").</param>
    /// <param name="days">Optional number of upcoming days to consider. If null, all future holidays are returned.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetUpcomingHolidaysAsync(string countryCode, int? days = null, HolidayType? type = null, CancellationToken cancellationToken = default);

#if NET6_0_OR_GREATER
    /// <summary>
    /// Retrieves a list of holidays occurring on a specific date across all countries.
    /// </summary>
    /// <param name="holidayDate">The specific date to look for holidays.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of holidays for a specific country on a specific date.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "US", "DE").</param>
    /// <param name="holidayDate">The date to search for holidays in the specified country.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateOnly holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default);
#else
    /// <summary>
    /// Retrieves a list of holidays occurring on a specific date across all countries.
    /// </summary>
    /// <param name="holidayDate">The specific date to look for holidays.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of holidays for a specific country on a specific date.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "US", "DE").</param>
    /// <param name="holidayDate">The date to search for holidays in the specified country.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, DateTime holidayDate, HolidayType? type = null, CancellationToken cancellationToken = default);
#endif

    /// <summary>
    /// Retrieves a list of holidays for a specific country and year.
    /// </summary>
    /// <param name="countryCode">The ISO 3166-1 alpha-2 country code (e.g., "US", "DE").</param>
    /// <param name="year">The year to retrieve holidays for.</param>
    /// <param name="type">Optional filter for specific types of holidays.</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="InvalidOperationException">The request failed due to deserialization issue.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<IReadOnlyList<HolidayModel>> GetHolidaysAsync(string countryCode, int year, HolidayType? type = null, CancellationToken cancellationToken = default);
}