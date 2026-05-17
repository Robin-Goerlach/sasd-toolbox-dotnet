namespace Sasd.Toolbox.Core;

/// <summary>
/// Provides small guard methods for validating method arguments.
/// </summary>
/// <remarks>
/// The guard class is deliberately small and dependency-free.
/// Later toolbox modules can use it without pulling in unrelated functionality.
/// </remarks>
public static class Guard
{
    /// <summary>
    /// Ensures that a reference value is not <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">The reference type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="parameterName">The name of the checked parameter.</param>
    /// <returns>The original value if it is not <see langword="null"/>.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="value"/> is <see langword="null"/>.
    /// </exception>
    public static T NotNull<T>(T? value, string parameterName)
        where T : class
    {
        // Returning the value makes the method pleasant to use at call sites:
        // var service = Guard.NotNull(inputService, nameof(inputService));
        return value ?? throw new ArgumentNullException(parameterName);
    }

    /// <summary>
    /// Ensures that a collection is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the collection.</typeparam>
    /// <param name="values">The collection to check.</param>
    /// <param name="parameterName">The name of the checked parameter.</param>
    /// <returns>The original collection if it is valid.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="values"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="values"/> is empty.
    /// </exception>
    public static IReadOnlyCollection<T> NotNullOrEmpty<T>(
        IReadOnlyCollection<T>? values,
        string parameterName)
    {
        if (values is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        if (values.Count == 0)
        {
            throw new ArgumentException("The collection must contain at least one element.", parameterName);
        }

        return values;
    }

    /// <summary>
    /// Ensures that a comparable value lies within the inclusive range
    /// defined by <paramref name="minimum"/> and <paramref name="maximum"/>.
    /// </summary>
    /// <typeparam name="T">The comparable value type.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="minimum">The inclusive lower bound.</param>
    /// <param name="maximum">The inclusive upper bound.</param>
    /// <param name="parameterName">The name of the checked parameter.</param>
    /// <returns>The original value if it lies inside the allowed range.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="minimum"/> is greater than <paramref name="maximum"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="value"/> is outside the allowed range.
    /// </exception>
    public static T InRange<T>(
        T value,
        T minimum,
        T maximum,
        string parameterName)
        where T : IComparable<T>
    {
        if (minimum.CompareTo(maximum) > 0)
        {
            throw new ArgumentException("The minimum value must not be greater than the maximum value.");
        }

        if (value.CompareTo(minimum) < 0 || value.CompareTo(maximum) > 0)
        {
            throw new ArgumentOutOfRangeException(
                parameterName,
                value,
                $"The value must be between {minimum} and {maximum}.");
        }

        return value;
    }

    /// <summary>
    /// Ensures that a floating-point value is finite.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <param name="parameterName">The name of the checked parameter.</param>
    /// <returns>The original value if it is finite.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="value"/> is <see cref="double.NaN"/>,
    /// <see cref="double.PositiveInfinity"/> or <see cref="double.NegativeInfinity"/>.
    /// </exception>
    public static double Finite(double value, string parameterName)
    {
        if (double.IsNaN(value) || double.IsInfinity(value))
        {
            throw new ArgumentException("The value must be finite.", parameterName);
        }

        return value;
    }
}
