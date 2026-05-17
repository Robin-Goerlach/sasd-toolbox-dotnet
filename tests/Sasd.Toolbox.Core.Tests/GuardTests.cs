using Sasd.Toolbox.Core;
using Xunit;

namespace Sasd.Toolbox.Core.Tests;

public sealed class GuardTests
{
    [Fact]
    public void NotNull_ReturnsOriginalValue_WhenValueIsNotNull()
    {
        var value = "SASD";

        var result = Guard.NotNull(value, nameof(value));

        Assert.Same(value, result);
    }

    [Fact]
    public void NotNull_ThrowsArgumentNullException_WhenValueIsNull()
    {
        string? value = null;

        Assert.Throws<ArgumentNullException>(() => Guard.NotNull(value, nameof(value)));
    }

    [Fact]
    public void NotNullOrEmpty_ReturnsCollection_WhenCollectionContainsValues()
    {
        IReadOnlyCollection<int> values = [1, 2, 3];

        var result = Guard.NotNullOrEmpty(values, nameof(values));

        Assert.Same(values, result);
    }

    [Fact]
    public void NotNullOrEmpty_ThrowsArgumentException_WhenCollectionIsEmpty()
    {
        IReadOnlyCollection<int> values = [];

        Assert.Throws<ArgumentException>(() => Guard.NotNullOrEmpty(values, nameof(values)));
    }

    [Fact]
    public void InRange_ReturnsValue_WhenValueIsInsideRange()
    {
        var result = Guard.InRange(5, 1, 10, "value");

        Assert.Equal(5, result);
    }

    [Fact]
    public void InRange_ThrowsArgumentOutOfRangeException_WhenValueIsOutsideRange()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Guard.InRange(11, 1, 10, "value"));
    }

    [Fact]
    public void Finite_ReturnsValue_WhenValueIsFinite()
    {
        var result = Guard.Finite(42.5, "value");

        Assert.Equal(42.5, result);
    }

    [Fact]
    public void Finite_ThrowsArgumentException_WhenValueIsNan()
    {
        Assert.Throws<ArgumentException>(() => Guard.Finite(double.NaN, "value"));
    }
}
