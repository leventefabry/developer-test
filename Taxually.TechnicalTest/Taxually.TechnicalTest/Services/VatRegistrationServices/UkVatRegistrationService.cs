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
            // ideally the API client would be a separate HTTP client service and the URL would be set there
            await httpClient.PostAsync("https://api.uktax.gov.uk", request);

            logger.LogInformation("Company has successfully been registered in the UK with Id: {CompanyId}",
                request.CompanyId);
            return Result.Success();
        }
        catch (Exception e)
        {
            logger.LogError(e,
                "Failed to register a company for VAT in the UK with Company Id: {CompanyId}, Company Name: {CompanyName}",
                request.CompanyId, request.CompanyName);
            return Result.Failure("Failed to register a company for VAT in the UK");
        }
    }
}