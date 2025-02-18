using System.Text;
using Taxually.TechnicalTest.Services;

namespace Taxually.TechnicalTest.Tests.UnitTests;

public class ExcelBuilderTests
{
	private readonly ExcelBuilder _excelBuilder = new();

	[Fact]
	public void CreateCsv_ValidInputs_ReturnsCorrectCsv()
	{
		// Arrange
		var companyName = "Test Company";
		var companyId = "12345";
		var expectedCsv = "CompanyName,CompanyId\r\nTest Company,12345\r\n";

		// Act
		var result = _excelBuilder.CreateCsv(companyName, companyId);
		var resultString = Encoding.UTF8.GetString(result);

		// Assert
		Assert.Equal(expectedCsv, resultString);
	}

	[Fact]
	public void CreateCsv_EmptyInputs_ReturnsCorrectCsv()
	{
		// Arrange
		var companyName = "";
		var companyId = "";
		var expectedCsv = "CompanyName,CompanyId\r\n,\r\n";

		// Act
		var result = _excelBuilder.CreateCsv(companyName, companyId);
		var resultString = Encoding.UTF8.GetString(result);

		// Assert
		Assert.Equal(expectedCsv, resultString);
	}
}