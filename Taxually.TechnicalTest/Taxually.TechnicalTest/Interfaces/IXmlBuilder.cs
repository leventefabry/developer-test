namespace Taxually.TechnicalTest.Interfaces;

public interface IXmlBuilder
{
    string GetXmlString<T>(T data) where T : class;
}