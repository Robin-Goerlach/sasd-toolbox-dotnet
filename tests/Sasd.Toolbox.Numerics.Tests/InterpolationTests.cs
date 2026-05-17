using Sasd.Toolbox.Numerics;
using Xunit;

namespace Sasd.Toolbox.Numerics.Tests;

public sealed class InterpolationTests
{
    [Fact]
    public void Linear_ReturnsInterpolatedValue()
    {
        var result = Interpolation.Linear(
            x0: 0,
            y0: 0,
            x1: 10,
            y1: 100,
            x: 2.5);

        Assert.Equal(25.0, result, precision: 10);
    }

    [Fact]
    public void Linear_ThrowsArgumentException_WhenXCoordinatesAreEqual()
    {
        Assert.Throws<ArgumentException>(() => Interpolation.Linear(
            x0: 1,
            y0: 0,
            x1: 1,
            y1: 100,
            x: 1));
    }
}
