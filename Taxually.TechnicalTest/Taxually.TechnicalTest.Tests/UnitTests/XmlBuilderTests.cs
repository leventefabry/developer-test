using Microsoft.Extensions.Logging;
using Moq;
using Taxually.TechnicalTest.Services;

namespace Taxually.TechnicalTest.Tests.UnitTests;

public class XmlBuilderTests
{
    private readonly XmlBuilder _xmlBuilder;

    public XmlBuilderTests()
    {
        Mock<ILogger<XmlBuilder>> loggerMock = new Mock<ILogger<XmlBuilder>>();
        _xmlBuilder = new XmlBuilder(loggerMock.Object);
    }

    public class TestData
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [Fact]
    public void GetXmlString_ValidData_ReturnsXmlString()
    {
        // Arrange
        var data = new TestData { Name = "Test", Value = "123" };
        var expectedXml =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<TestData xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Name>Test</Name>\r\n  <Value>123</Value>\r\n</TestData>";

        // Act
        var result = _xmlBuilder.GetXmlString(data);

        // Assert
        Assert.Equal(expectedXml, result);
    }

    [Fact]
    public void GetXmlString_NullData_ThrowsInvalidOperationException()
    {
        // Arrange
        TestData? data = null;

        // Act & Assert
#pragma warning disable CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
        Assert.Throws<InvalidOperationException>(() => _xmlBuilder.GetXmlString(data));
#pragma warning restore CS8634 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.
    }
}