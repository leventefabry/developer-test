using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services.VatRegistrationServices;

public class UkVatRegistrationService(
    ITaxuallyHttpClient httpClient,
    ILogger<UkVatRegistrationService> logger) : IVatRegistrationService
{
    public string CountryCode => "uk";

    public async Task<Result> RegisterAsync(VatRegistrationRequest request)
    {
        try
        {
            // UK has an API to register for a VAT number
            await httpClient.PostAsync("https://api.uktax.gov.uk", request);

            return Result.Success();
        }
        catch (Exception e)
        {
            logger.LogError(e,
                "Failed to register company for VAT in UK with Company Id: {CompanyId}, Company Name: {CompanyName}",
                request.CompanyId, request.CompanyName);
            return Result.Failure("Failed to register company for VAT in UK");
        }
    }
}