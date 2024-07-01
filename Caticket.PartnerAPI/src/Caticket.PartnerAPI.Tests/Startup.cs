using Caticket.PartnerAPI.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Caticket.PartnerAPI.Tests;

public class Startup : TestBedFixture
{
    protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
    {
        services.AddScoped<EventService>();
    }

    protected override ValueTask DisposeAsyncCore()
    {
        throw new NotImplementedException();
    }

    protected override IEnumerable<TestAppSettings> GetTestAppSettings()
    {
        throw new NotImplementedException();
    }
}