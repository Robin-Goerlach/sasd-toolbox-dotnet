using Sasd.Toolbox.Core;

namespace Sasd.Toolbox.Numerics;

/// <summary>
/// Provides basic statistical helper methods.
/// </summary>
/// <remarks>
/// The implementation intentionally favors readability over micro-optimization.
/// For v0.1.0 this is more useful than clever code because the project should
/// be understandable, testable and easy to extend later.
/// </remarks>
public static class Statistics
{
    /// <summary>
    /// Calculates the arithmetic mean of a sequence of finite values.
    /// </summary>
    /// <param name="values">The values to evaluate.</param>
    /// <returns>The arithmetic mean.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="values"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="values"/> is empty or contains a non-finite value.
    /// </exception>
    public static double Mean(IEnumerable<double> values)
    {
        var data = ToValidatedArray(values, nameof(values));

        var sum = 0.0;

        // A simple loop is used instead of LINQ Sum() so that the code remains
        // easy to step through while learning or debugging.
        foreach (var value in data)
        {
            sum += value;
        }

        return sum / data.Length;
    }

    /// <summary>
    /// Calculates the median value of a sequence of finite values.
    /// </summary>
    /// <param name="values">The values to evaluate.</param>
    /// <returns>The median value.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="values"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="values"/> is empty or contains a non-finite value.
    /// </exception>
    public static double Median(IEnumerable<double> values)
    {
        var data = ToValidatedArray(values, nameof(values));

        // Sorting a local copy avoids changing the caller's data.
        Array.Sort(data);

        var middle = data.Length / 2;

        if (data.Length % 2 == 1)
        {
            return data[middle];
        }

        return (data[middle - 1] + data[middle]) / 2.0;
    }

    /// <summary>
    /// Calculates population or sample variance for a sequence of finite values.
    /// </summary>
    /// <param name="values">The values to evaluate.</param>
    /// <param name="mode">The variance calculation mode.</param>
    /// <returns>The calculated variance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="values"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="values"/> is empty, contains a non-finite value
    /// or when sample variance is requested for fewer than two values.
    /// </exception>
    public static double Variance(
        IEnumerable<double> values,
        VarianceMode mode = VarianceMode.Population)
    {
        var data = ToValidatedArray(values, nameof(values));

        if (mode == VarianceMode.Sample && data.Length < 2)
        {
            throw new ArgumentException(
                "Sample variance requires at least two values.",
                nameof(values));
        }

        var mean = Mean(data);
        var sumOfSquaredDistances = 0.0;

        foreach (var value in data)
        {
            var distance = value - mean;
            sumOfSquaredDistances += distance * distance;
        }

        var denominator = mode == VarianceMode.Population
            ? data.Length
            : data.Length - 1;

        return sumOfSquaredDistances / denominator;
    }

    /// <summary>
    /// Converts a sequence to an array and validates that it contains at least
    /// one finite value.
    /// </summary>
    /// <param name="values">The source sequence.</param>
    /// <param name="parameterName">The name of the checked parameter.</param>
    /// <returns>A validated array copy of the input values.</returns>
    private static double[] ToValidatedArray(
        IEnumerable<double> values,
        string parameterName)
    {
        Guard.NotNull(values, parameterName);

        var data = values.ToArray();

        if (data.Length == 0)
        {
            throw new ArgumentException("The sequence must contain at least one value.", parameterName);
        }

        for (var i = 0; i < data.Length; i++)
        {
            Guard.Finite(data[i], $"{parameterName}[{i}]");
        }

        return data;
    }
}
