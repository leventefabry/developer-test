using System.Xml.Serialization;
using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services.VatRegistrationServices;

public class GermanyVatRegistrationService(
    ITaxuallyQueueClient xmlQueueClient,
    IXmlBuilder xmlBuilder,
    ILogger<GermanyVatRegistrationService> logger) : IVatRegistrationService
{
    public string CountryCode => "de";

    public async Task<Result> RegisterAsync(VatRegistrationRequest request)
    {
        try
        {
            // Germany requires an XML document to be uploaded to register for a VAT number
            var xml = xmlBuilder.GetXmlString(request);

            // Queue xml doc to be processed
            await xmlQueueClient.EnqueueAsync("vat-registration-xml", xml);

            return Result.Success();
        }
        catch (Exception e)
        {
            logger.LogError(e,
                "Failed to register a company for VAT in Germany with Company Id: {CompanyId}, Company Name: {CompanyName}",
                request.CompanyId, request.CompanyName);
            return Result.Failure("Failed to register a company for VAT in Germany");
        }
    }
}