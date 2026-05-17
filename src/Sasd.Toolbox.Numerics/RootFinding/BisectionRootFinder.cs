using Sasd.Toolbox.Core;

namespace Sasd.Toolbox.Numerics.RootFinding;

/// <summary>
/// Finds real-valued roots by using the bisection method.
/// </summary>
/// <remarks>
/// The bisection method is slow compared to some advanced methods, but it is
/// robust and easy to understand. This makes it a good first algorithm for the
/// numerics preview release.
/// </remarks>
public static class BisectionRootFinder
{
    /// <summary>
    /// Finds a root of a continuous function inside the interval
    /// <paramref name="lowerBound"/> to <paramref name="upperBound"/>.
    /// </summary>
    /// <param name="function">The function whose root should be found.</param>
    /// <param name="lowerBound">The lower interval bound.</param>
    /// <param name="upperBound">The upper interval bound.</param>
    /// <param name="options">Optional bisection configuration.</param>
    /// <returns>A root-finding result containing root, residual and iteration count.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="function"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when bounds are invalid, function values are not finite or the
    /// interval does not bracket a root.
    /// </exception>
    public static RootFindingResult FindRoot(
        Func<double, double> function,
        double lowerBound,
        double upperBound,
        BisectionOptions? options = null)
    {
        Guard.NotNull(function, nameof(function));
        Guard.Finite(lowerBound, nameof(lowerBound));
        Guard.Finite(upperBound, nameof(upperBound));

        if (lowerBound >= upperBound)
        {
            throw new ArgumentException("The lower bound must be smaller than the upper bound.");
        }

        var safeOptions = BisectionOptions.ValidateOrDefault(options);

        var a = lowerBound;
        var b = upperBound;
        var fa = EvaluateFinite(function, a, nameof(lowerBound));
        var fb = EvaluateFinite(function, b, nameof(upperBound));

        if (IsCloseEnough(fa, safeOptions.Tolerance))
        {
            return new RootFindingResult(a, fa, 0, true);
        }

        if (IsCloseEnough(fb, safeOptions.Tolerance))
        {
            return new RootFindingResult(b, fb, 0, true);
        }

        if (HaveSameSign(fa, fb))
        {
            throw new ArgumentException(
                "The function values at the interval bounds must have opposite signs.");
        }

        var midpoint = double.NaN;
        var fmid = double.NaN;

        for (var iteration = 1; iteration <= safeOptions.MaxIterations; iteration++)
        {
            // This midpoint formula avoids overflow better than (a + b) / 2.
            midpoint = a + ((b - a) / 2.0);
            fmid = EvaluateFinite(function, midpoint, nameof(function));

            var halfIntervalWidth = Math.Abs(b - a) / 2.0;

            if (IsCloseEnough(fmid, safeOptions.Tolerance) ||
                halfIntervalWidth <= safeOptions.Tolerance)
            {
                return new RootFindingResult(midpoint, fmid, iteration, true);
            }

            // Keep the half-interval that still brackets a root.
            if (HaveSameSign(fa, fmid))
            {
                a = midpoint;
                fa = fmid;
            }
            else
            {
                b = midpoint;
                fb = fmid;
            }
        }

        return new RootFindingResult(
            midpoint,
            fmid,
            safeOptions.MaxIterations,
            false);
    }

    /// <summary>
    /// Evaluates the function and ensures the result is finite.
    /// </summary>
    private static double EvaluateFinite(
        Func<double, double> function,
        double x,
        string parameterName)
    {
        var value = function(x);
        Guard.Finite(value, parameterName);
        return value;
    }

    /// <summary>
    /// Returns true if both values have the same mathematical sign.
    /// </summary>
    private static bool HaveSameSign(double left, double right)
    {
        return (left > 0 && right > 0) || (left < 0 && right < 0);
    }

    /// <summary>
    /// Returns true if a value is close enough to zero for the current tolerance.
    /// </summary>
    private static bool IsCloseEnough(double value, double tolerance)
    {
        return Math.Abs(value) <= tolerance;
    }
}
