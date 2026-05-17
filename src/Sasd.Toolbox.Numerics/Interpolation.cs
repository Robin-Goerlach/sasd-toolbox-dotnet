using Sasd.Toolbox.Core;

namespace Sasd.Toolbox.Numerics;

/// <summary>
/// Provides interpolation helper methods.
/// </summary>
public static class Interpolation
{
    /// <summary>
    /// Performs linear interpolation between two points.
    /// </summary>
    /// <param name="x0">The x-coordinate of the first point.</param>
    /// <param name="y0">The y-coordinate of the first point.</param>
    /// <param name="x1">The x-coordinate of the second point.</param>
    /// <param name="y1">The y-coordinate of the second point.</param>
    /// <param name="x">The x-coordinate for which the interpolated y-value should be calculated.</param>
    /// <returns>The interpolated y-value.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when any value is not finite or when <paramref name="x0"/> and
    /// <paramref name="x1"/> are equal.
    /// </exception>
    public static double Linear(
        double x0,
        double y0,
        double x1,
        double y1,
        double x)
    {
        Guard.Finite(x0, nameof(x0));
        Guard.Finite(y0, nameof(y0));
        Guard.Finite(x1, nameof(x1));
        Guard.Finite(y1, nameof(y1));
        Guard.Finite(x, nameof(x));

        if (x0.Equals(x1))
        {
            throw new ArgumentException("The x-coordinates must not be equal.");
        }

        // Linear interpolation formula:
        // y = y0 + (x - x0) * (y1 - y0) / (x1 - x0)
        return y0 + ((x - x0) * (y1 - y0) / (x1 - x0));
    }
}
