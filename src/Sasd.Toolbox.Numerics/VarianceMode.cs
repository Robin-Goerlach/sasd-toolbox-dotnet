namespace Sasd.Toolbox.Numerics;

/// <summary>
/// Defines how variance should be calculated.
/// </summary>
public enum VarianceMode
{
    /// <summary>
    /// Calculates population variance by dividing by <c>n</c>.
    /// </summary>
    Population,

    /// <summary>
    /// Calculates sample variance by dividing by <c>n - 1</c>.
    /// </summary>
    Sample
}
