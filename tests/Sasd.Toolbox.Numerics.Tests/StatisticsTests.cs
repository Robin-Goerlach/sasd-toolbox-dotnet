using Sasd.Toolbox.Numerics;
using Xunit;

namespace Sasd.Toolbox.Numerics.Tests;

public sealed class StatisticsTests
{
    [Fact]
    public void Mean_ReturnsArithmeticMean()
    {
        double[] values = [2, 4, 4, 4, 5, 5, 7, 9];

        var result = Statistics.Mean(values);

        Assert.Equal(5.0, result, precision: 10);
    }

    [Fact]
    public void Median_ReturnsMiddleValue_ForOddNumberOfValues()
    {
        double[] values = [9, 1, 5];

        var result = Statistics.Median(values);

        Assert.Equal(5.0, result, precision: 10);
    }

    [Fact]
    public void Median_ReturnsAverageOfTwoMiddleValues_ForEvenNumberOfValues()
    {
        double[] values = [9, 1, 5, 7];

        var result = Statistics.Median(values);

        Assert.Equal(6.0, result, precision: 10);
    }

    [Fact]
    public void Variance_ReturnsPopulationVariance()
    {
        double[] values = [2, 4, 4, 4, 5, 5, 7, 9];

        var result = Statistics.Variance(values, VarianceMode.Population);

        Assert.Equal(4.0, result, precision: 10);
    }

    [Fact]
    public void Variance_ReturnsSampleVariance()
    {
        double[] values = [2, 4, 4, 4, 5, 5, 7, 9];

        var result = Statistics.Variance(values, VarianceMode.Sample);

        Assert.Equal(32.0 / 7.0, result, precision: 10);
    }

    [Fact]
    public void Mean_ThrowsArgumentException_ForEmptySequence()
    {
        double[] values = [];

        Assert.Throws<ArgumentException>(() => Statistics.Mean(values));
    }

    [Fact]
    public void Mean_ThrowsArgumentException_ForNonFiniteValue()
    {
        double[] values = [1, double.PositiveInfinity];

        Assert.Throws<ArgumentException>(() => Statistics.Mean(values));
    }
}
