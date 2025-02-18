using System.ComponentModel.DataAnnotations;

namespace Taxually.TechnicalTest.Contracts.Requests;

public record VatRegistrationRequest
{
    [Required]
    [MaxLength(250)]
    public required string CompanyName { get; init; }
    
    [Required]
    [MaxLength(250)]
    public required string CompanyId { get; init; }
    
    [Required]
    // I used this solution for the simplicity but in a real-world scenario I would use FluentValidation
    [RegularExpression("uk|fr|de|UK|FR|DE", ErrorMessage = "Invalid Country Code")]
    public required string Country { get; init; }
}