namespace Sasd.Toolbox.Numerics.RootFinding;

/// <summary>
/// Represents the result of a numerical root-finding operation.
/// </summary>
/// <param name="Root">The calculated root approximation.</param>
/// <param name="FunctionValue">The function value at <paramref name="Root"/>.</param>
/// <param name="Iterations">The number of iterations used.</param>
/// <param name="Converged">Indicates whether the method converged within the configured tolerance.</param>
public readonly record struct RootFindingResult(
    double Root,
    double FunctionValue,
    int Iterations,
    bool Converged);
