using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Taxually.TechnicalTest.Contracts.Requests;

namespace Taxually.TechnicalTest.Tests.IntegrationTesting;

public class VatRegistrationTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Post_FranceValidRequest_ReturnsNoContent()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "fr"
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/VatRegistration", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task Post_UkValidRequest_ReturnsNoContent()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "uk"
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/VatRegistration", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task Post_DeValidRequest_ReturnsNoContent()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "de"
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/VatRegistration", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }
    
    [Fact]
    public async Task Post_ValidCapitalLetterCountryRequest_ReturnsNoContent()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "FR"
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/VatRegistration", content);

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Post_InvalidCountry_ReturnsBadRequest()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "invalid"
        };
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/VatRegistration", content);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}