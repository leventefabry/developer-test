using System.Text;
using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services.VatRegistrationServices;

public class FranceVatRegistrationService(
    ITaxuallyQueueClient excelQueueClient,
    IExcelBuilder excelBuilder,
    ILogger<FranceVatRegistrationService> logger) : IVatRegistrationService
{
    public string CountryCode => "fr";

    public async Task<Result> RegisterAsync(VatRegistrationRequest request)
    {
        try
        {
            // France requires an excel spreadsheet to be uploaded to register for a VAT number
            var csv = excelBuilder.CreateCsv(request.CompanyName, request.CompanyId);

            // Queue file to be processed
            await excelQueueClient.EnqueueAsync("vat-registration-csv", csv);

            return Result.Success();
        }
        catch (Exception e)
        {
            logger.LogError(e,
                "Failed to register a company for VAT in France with Company Id: {CompanyId}, Company Name: {CompanyName}",
                request.CompanyId, request.CompanyName);
            return Result.Failure("Failed to register a company for VAT in France");
        }
    }
}