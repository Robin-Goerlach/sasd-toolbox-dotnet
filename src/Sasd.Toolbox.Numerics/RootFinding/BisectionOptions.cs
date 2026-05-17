using Sasd.Toolbox.Core;

namespace Sasd.Toolbox.Numerics.RootFinding;

/// <summary>
/// Defines configuration options for the bisection root-finding method.
/// </summary>
/// <param name="Tolerance">
/// The accepted tolerance for the root approximation.
/// </param>
/// <param name="MaxIterations">
/// The maximum number of bisection steps.
/// </param>
public sealed record BisectionOptions(
    double Tolerance = 1e-10,
    int MaxIterations = 100)
{
    /// <summary>
    /// Validates the options and returns a safe instance.
    /// </summary>
    /// <param name="options">The options to validate, or <see langword="null"/> for defaults.</param>
    /// <returns>A validated options instance.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when tolerance is invalid.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when maximum iterations is outside the allowed range.
    /// </exception>
    internal static BisectionOptions ValidateOrDefault(BisectionOptions? options)
    {
        var safeOptions = options ?? new BisectionOptions();

        Guard.Finite(safeOptions.Tolerance, nameof(Tolerance));
        Guard.InRange(safeOptions.MaxIterations, 1, 1_000_000, nameof(MaxIterations));

        if (safeOptions.Tolerance <= 0)
        {
            throw new ArgumentException("Tolerance must be greater than zero.", nameof(Tolerance));
        }

        return safeOptions;
    }
}
