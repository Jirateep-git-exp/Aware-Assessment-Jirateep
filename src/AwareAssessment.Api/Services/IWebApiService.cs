using AwareAssessment.Api.Models;

namespace AwareAssessment.Api.Services;

public interface IWebApiService
{
    Task<WebApiResponse> GetUserAsync(int id, CancellationToken cancellationToken = default);
    Task<WebApiResponse> GetUsersAsync(CancellationToken cancellationToken = default);
}
