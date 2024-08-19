
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Onyx.Product.Infrastructure.Health
{
    public sealed class DatabaseHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
