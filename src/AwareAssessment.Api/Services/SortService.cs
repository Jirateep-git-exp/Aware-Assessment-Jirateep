using System.Globalization;

namespace AwareAssessment.Api.Services;

public class SortService : ISortService
{
    public IReadOnlyList<string> GetDuplicateSortedRanks(string input)
    {
        var duplicates = input
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .GroupBy(value => value, StringComparer.Ordinal)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key)
            .ToList();

        var textValues = duplicates
            .Where(value => !IsNumericToken(value))
            .OrderBy(value => value, StringComparer.Ordinal);

        var numericValues = duplicates
            .Where(IsNumericToken)
            .OrderBy(value => decimal.Parse(value, NumberStyles.Number, CultureInfo.InvariantCulture));

        return textValues.Concat(numericValues).ToList();
    }

    private static bool IsNumericToken(string value) =>
        decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
}
