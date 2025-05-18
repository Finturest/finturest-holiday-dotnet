using Finturest.Holiday.Abstractions;
using Finturest.Holiday.Constants;
using Finturest.Holiday.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finturest.Holiday.DependencyInjection;

/// <summary>
/// Provides extension methods to register the Finturest Holiday API client and its dependencies with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds and configures the Finturest Holiday client using configuration from the specified <see cref="IConfigurationSection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configurationSection">The configuration section containing settings for <see cref="HolidayOptions"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="services"/> or <paramref name="configurationSection"/> is <c>null</c>.</exception>
    public static IServiceCollection AddFinturestHoliday(this IServiceCollection services, IConfigurationSection configurationSection)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configurationSection);
#else
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configurationSection is null)
        {
            throw new ArgumentNullException(nameof(configurationSection));
        }
#endif

        services.Configure<HolidayOptions>(configurationSection);

        services.AddFinturestHoliday();

        return services;
    }

    /// <summary>
    /// Adds and configures the Finturest Holiday client using an action delegate to set <see cref="HolidayOptions"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configureOptions">An action delegate to configure the <see cref="HolidayOptions"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="services"/> or <paramref name="configureOptions"/> is <c>null</c>.</exception>
    public static IServiceCollection AddFinturestHoliday(this IServiceCollection services, Action<HolidayOptions> configureOptions)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);
#else
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configureOptions is null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }
#endif

        services.Configure(configureOptions);

        services.AddFinturestHoliday();

        return services;
    }

    private static IServiceCollection AddFinturestHoliday(this IServiceCollection services)
    {
        services.AddHttpClient<IHolidayServiceClient, HolidayServiceClient>((serviceProvider, client) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<HolidayOptions>>().Value;

            client.BaseAddress = new Uri(options.BaseAddress);

            client.DefaultRequestHeaders.Add(HeaderConstants.ApiKey, options.ApiKey);
        });

        return services;
    }
}
