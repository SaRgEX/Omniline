using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OmnilineDbContext>();
        services.AddScoped<IContact, ContactRepository>();
        services.AddScoped<ICounterparty, CounterpartyRepository>();
        return services;
    }
}