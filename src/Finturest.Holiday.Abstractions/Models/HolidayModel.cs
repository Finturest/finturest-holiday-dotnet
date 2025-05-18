using Finturest.Holiday.Abstractions.Models.Enums;

namespace Finturest.Holiday.Abstractions.Models;

/// <summary>
/// Represents a public holiday in a specific country.
/// </summary>
public record HolidayModel
{
    /// <summary>
    /// The specific date the holiday occurs.
    /// </summary>
#if NET6_0_OR_GREATER
#if NET7_0_OR_GREATER
    public required DateOnly Date { get; init; }
#else
    public DateOnly Date { get; init; }
#endif
#else
    public DateTime Date { get; set; }
#endif

    /// <summary>
    /// The official name of the holiday in English.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Name { get; init; }
#else
    public string Name { get; set; } = null!;
#endif

    /// <summary>
    /// The name of the holiday in the local language of the country.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string LocalName { get; init; }
#else
    public string LocalName { get; set; } = null!;
#endif

    /// <summary>
    /// Indicates whether the holiday is nationwide.
    /// </summary>
#if NET7_0_OR_GREATER
    public required bool Nationwide { get; init; }
#else
    public bool Nationwide { get; set; }
#endif

    /// <summary>
    /// The country in which the holiday is observed.
    /// </summary>
#if NET7_0_OR_GREATER
    public required CountryBasicModel Country { get; init; }
#else
    public CountryBasicModel Country { get; set; } = null!;
#endif

    /// <summary>
    /// A list of ISO 3166-2 subdivisions (e.g., states, provinces) where the holiday is observed.
    /// </summary>
#if NET7_0_OR_GREATER
    public IReadOnlyList<string> Subdivisions { get; init; } = [];
#else
    public IReadOnlyList<string> Subdivisions { get; set; } = [];
#endif

    /// <summary>
    /// A list of types that categorize the holiday (e.g., public, religious).
    /// </summary>
#if NET7_0_OR_GREATER
    public IReadOnlyList<HolidayType> Types { get; init; } = [];
#else
    public IReadOnlyList<HolidayType> Types { get; set; } = [];
#endif
}
