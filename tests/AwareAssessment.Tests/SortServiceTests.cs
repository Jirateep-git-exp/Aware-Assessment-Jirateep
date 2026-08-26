using AwareAssessment.Api.Services;
using Xunit;

namespace AwareAssessment.Tests;

public class SortServiceTests
{
    private readonly SortService _service = new();

    [Fact]
    public void ReturnsOnlyDuplicatedValues_AndSortsLettersThenNumbers()
    {
        var result = _service.GetDuplicateSortedRanks("A,B,1,2,1,AA,3,5,BB,4,2,4,AA,B");

        Assert.Equal(new[] { "AA", "B", "1", "2", "4" }, result);
    }

    [Fact]
    public void ReturnsOnlyDuplicatedNumbers()
    {
        var result = _service.GetDuplicateSortedRanks("1,2,1,3,5,4,2,4");

        Assert.Equal(new[] { "1", "2", "4" }, result);
    }

    [Fact]
    public void SortsNumericValuesNumerically_NotLexicographically()
    {
        var result = _service.GetDuplicateSortedRanks("10,2,10,2,100,100");

        Assert.Equal(new[] { "2", "10", "100" }, result);
    }
}
