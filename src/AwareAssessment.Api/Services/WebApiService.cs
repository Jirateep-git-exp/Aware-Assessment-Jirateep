using System.Net.Http.Json;
using AwareAssessment.Api.Models;

namespace AwareAssessment.Api.Services;

public class WebApiService(HttpClient httpClient) : IWebApiService
{
    public async Task<WebApiResponse> GetUserAsync(int id, CancellationToken cancellationToken = default)
    {
        var url = $"https://jsonplaceholder.typicode.com/users/{id}";
        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken);
        return new WebApiResponse(url, "GET", body ?? new { });
    }

    public async Task<WebApiResponse> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        var url = "https://jsonplaceholder.typicode.com/users";
        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<object>(cancellationToken: cancellationToken);
        return new WebApiResponse(url, "GET", body ?? new { });
    }
}
