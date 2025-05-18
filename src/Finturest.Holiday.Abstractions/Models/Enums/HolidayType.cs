namespace Finturest.Holiday.Abstractions.Models.Enums;

public enum HolidayType
{
    /// <summary>
    /// Official public holiday with paid time off
    /// </summary>
    Public = 0,

    /// <summary>
    /// Banks and possibly offices closed
    /// </summary>
    Bank = 1,

    /// <summary>
    /// Schools closed
    /// </summary>
    School = 2,

    /// <summary>
    /// Government and civil authorities closed
    /// </summary>
    Government = 3,

    /// <summary>
    /// Most people take a day off, but not mandated
    /// </summary>
    Unofficial = 4,

    /// <summary>
    /// Cultural/religious event; no day off required
    /// </summary>
    Observance = 5
}
