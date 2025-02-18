namespace Taxually.TechnicalTest.Contracts.Requests;

public readonly record struct VatRegistrationRequest
{
    public string CompanyName { get; init; }
    
    public string CompanyId { get; init; }
    
    public string Country { get; init; }
}