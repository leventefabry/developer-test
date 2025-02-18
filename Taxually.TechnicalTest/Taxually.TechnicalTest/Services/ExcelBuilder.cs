using System.Text;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services;

public class ExcelBuilder : IExcelBuilder
{
    public byte[] CreateCsv(string companyName, string companyId)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("CompanyName,CompanyId");
        csvBuilder.AppendLine($"{companyName}{companyId}");
        return Encoding.UTF8.GetBytes(csvBuilder.ToString());
    }
}