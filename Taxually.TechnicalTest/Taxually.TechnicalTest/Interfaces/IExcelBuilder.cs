namespace Taxually.TechnicalTest.Interfaces;

public interface IExcelBuilder
{
    byte[] CreateCsv(string companyName, string companyId);
}