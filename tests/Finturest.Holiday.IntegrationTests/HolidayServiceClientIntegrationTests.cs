using System.Net;
using System.Net.Http;

using Finturest.Holiday.Abstractions;
using Finturest.Holiday.DependencyInjection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finturest.Holiday.IntegrationTests;

/// <summary>
/// Integration tests for <see cref="IHolidayServiceClient"/>
/// </summary>
public partial class HolidayServiceClientIntegrationTests
{
    private readonly IHolidayServiceClient _sut;

    public HolidayServiceClientIntegrationTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
#if DEBUG
            .AddUserSecrets<HolidayServiceClientIntegrationTests>()
#endif
            .Build();

        var apiKey = configuration["Holiday:ApiKey"] ?? throw new InvalidOperationException("Finturest Holiday API key must be set in environment or user secrets.");

        _sut = BuildClient(apiKey);
    }

    [Fact]
    public async Task SendRequestAsync_ApiKeyIsNotValid_EnsureUnauthorizedStatusCode()
    {
        // Act
        Func<Task> action = async () => await BuildClient(apiKey: "invalid-api-key").GetUpcomingHolidaysAsync(countryCode: "PL").ConfigureAwait(false);

        // Assert
#if NET5_0_OR_GREATER
        var assertion = await action.ShouldThrowAsync<HttpRequestException>();

        assertion.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
#else
        await action.ShouldThrowAsync<HttpRequestException>();
#endif
    }

    private static IHolidayServiceClient BuildClient(string apiKey)
    {
        var services = new ServiceCollection();

        services.AddFinturestHoliday(options =>
        {
            options.ApiKey = apiKey;
        });

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<IHolidayServiceClient>();
    }
}
