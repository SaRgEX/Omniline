using System.Reflection;
using Application.Contracts;
using Application.Profiles;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection ConfigureApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<ICounterpartyService, CounterpartyService>();
        return services;
    }
}