using AwareAssessment.Api.Models;

namespace AwareAssessment.Api.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductResponse>> GetProductsAsync(CancellationToken cancellationToken = default);
}
