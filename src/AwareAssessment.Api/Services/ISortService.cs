namespace AwareAssessment.Api.Services;

public interface ISortService
{
    IReadOnlyList<string> GetDuplicateSortedRanks(string input);
}
