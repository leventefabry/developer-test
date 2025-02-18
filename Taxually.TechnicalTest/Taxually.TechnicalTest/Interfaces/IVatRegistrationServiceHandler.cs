using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;

namespace Taxually.TechnicalTest.Interfaces;

public interface IVatRegistrationServiceHandler
{
    Task<Result> RegisterVatAsync(VatRegistrationRequest request);
}