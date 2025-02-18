using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;

namespace Taxually.TechnicalTest.Interfaces;

public interface IVatRegistrationService
{
    string CountryCode { get; }

    Task<Result> RegisterAsync(VatRegistrationRequest request);
}