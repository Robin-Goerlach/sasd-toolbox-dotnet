using Sasd.Toolbox.Numerics.RootFinding;
using Xunit;

namespace Sasd.Toolbox.Numerics.Tests;

public sealed class BisectionRootFinderTests
{
    [Fact]
    public void FindRoot_FindsSquareRootOfTwo()
    {
        var result = BisectionRootFinder.FindRoot(
            function: x => (x * x) - 2.0,
            lowerBound: 1.0,
            upperBound: 2.0,
            options: new BisectionOptions(Tolerance: 1e-12, MaxIterations: 200));

        Assert.True(result.Converged);
        Assert.Equal(Math.Sqrt(2.0), result.Root, precision: 10);
    }

    [Fact]
    public void FindRoot_ThrowsArgumentException_WhenIntervalDoesNotBracketRoot()
    {
        Assert.Throws<ArgumentException>(() => BisectionRootFinder.FindRoot(
            function: x => (x * x) + 1.0,
            lowerBound: -1.0,
            upperBound: 1.0));
    }

    [Fact]
    public void FindRoot_ReturnsLowerBound_WhenLowerBoundIsAlreadyRoot()
    {
        var result = BisectionRootFinder.FindRoot(
            function: x => x,
            lowerBound: 0.0,
            upperBound: 2.0);

        Assert.True(result.Converged);
        Assert.Equal(0.0, result.Root, precision: 10);
        Assert.Equal(0, result.Iterations);
    }
}
