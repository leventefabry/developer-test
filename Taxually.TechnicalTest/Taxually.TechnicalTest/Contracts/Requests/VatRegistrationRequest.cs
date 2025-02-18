using System.ComponentModel.DataAnnotations;

namespace Taxually.TechnicalTest.Contracts.Requests;

public readonly record struct VatRegistrationRequest
{
    [Required]
    [MaxLength(250)]
    public string CompanyName { get; init; }
    
    [Required]
    [MaxLength(250)]
    public string CompanyId { get; init; }
    
    [Required]
    // I used this solution for the simplicity but in a real-world scenario I would use FluentValidation
    [RegularExpression("uk|fr|de|UK|FR|DE", ErrorMessage = "Invalid Country Code")]
    public string Country { get; init; }
}