using Microsoft.Extensions.Logging;
using Moq;
using Taxually.TechnicalTest.Common;
using Taxually.TechnicalTest.Contracts.Requests;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Services;

namespace Taxually.TechnicalTest.Tests.UnitTests;

public class VatRegistrationServiceHandlerTests
{
    private readonly Mock<Func<IEnumerable<IVatRegistrationService>>> _vatServiceFactoryMock;
    private readonly VatRegistrationServiceHandler _handler;

    public VatRegistrationServiceHandlerTests()
    {
        _vatServiceFactoryMock = new Mock<Func<IEnumerable<IVatRegistrationService>>>();
        Mock<ILogger<VatRegistrationServiceHandler>> loggerMock = new Mock<ILogger<VatRegistrationServiceHandler>>();
        _handler = new VatRegistrationServiceHandler(_vatServiceFactoryMock.Object, loggerMock.Object);
    }

    [Fact]
    public async Task RegisterVatAsync_ServiceFound_ReturnsSuccess()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "UK"
        };

        var serviceMock = new Mock<IVatRegistrationService>();
        serviceMock.Setup(s => s.CountryCode).Returns("uk");
        serviceMock.Setup(s => s.RegisterAsync(request)).ReturnsAsync(Result.Success());

        _vatServiceFactoryMock.Setup(f => f()).Returns(new List<IVatRegistrationService> { serviceMock.Object });

        // Act
        var result = await _handler.RegisterVatAsync(request);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Null(result.Error);
    }

    [Fact]
    public async Task RegisterVatAsync_ServiceNotFound_ReturnsFailure()
    {
        // Arrange
        var request = new VatRegistrationRequest
        {
            CompanyName = "Test Company",
            CompanyId = "12345",
            Country = "UK"
        };

        _vatServiceFactoryMock.Setup(f => f()).Returns(new List<IVatRegistrationService>());

        // Act
        var result = await _handler.RegisterVatAsync(request);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Country UK does not exist", result.Error);
    }
}
