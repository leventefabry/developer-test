using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Services;
using Taxually.TechnicalTest.Services.VatRegistrationServices;

namespace Taxually.TechnicalTest.Extensions;

public static class ServiceExtensions
{
    public static void RegisterClients(this IServiceCollection services)
    {
        services.AddScoped<ITaxuallyQueueClient, TaxuallyQueueClient>();
        services.AddScoped<ITaxuallyHttpClient, TaxuallyHttpClient>();
    }

    public static void RegisterVatServices(this IServiceCollection services)
    {
        services.AddScoped<IVatRegistrationService, UkVatRegistrationService>();
        services.AddScoped<IVatRegistrationService, FranceVatRegistrationService>();
        services.AddScoped<IVatRegistrationService, GermanyVatRegistrationService>();
        
        services.AddScoped<IVatRegistrationServiceHandler, VatRegistrationServiceHandler>();
        services.AddScoped<Func<IEnumerable<IVatRegistrationService>>>(x =>
            () => x.GetService<IEnumerable<IVatRegistrationService>>() ?? Array.Empty<IVatRegistrationService>());
    }
}