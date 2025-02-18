using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services;

public class VatRegistrationServiceHandler(
    Func<IEnumerable<IVatRegistrationService>> vatServiceFactory,
    ILogger<VatRegistrationServiceHandler> logger)
    : IVatRegistrationServiceHandler
{
    public async Task<Result> RegisterVatAsync(VatRegistrationRequest request)
    {
        var factory = vatServiceFactory();
        var requiredService =
            factory.FirstOrDefault(f => f.CountryCode.Equals(request.Country, StringComparison.OrdinalIgnoreCase));
        if (requiredService is null)
        {
            logger.LogError(
                "Country with country code: {Country} doesn't exist. CompanyId: {CompanyId}, CompanyName:{CompanyName}",
                request.Country,
                request.CompanyId,
                request.CompanyName);

            return Result.Failure($"Country {request.Country} does not exist");
        }
        
        // add generic pre processors, db read/write etc...

        await requiredService.RegisterAsync(request);
        
        // add generic post processors, audit, db read/write etc...
        
        return Result.Success();
    }
}