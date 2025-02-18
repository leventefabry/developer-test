using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services;

public class XmlBuilder : IXmlBuilder
{
    public string GetXmlString<T>(T data) where T : class
    {
        using var stringWriter = new StringWriter();
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(stringWriter, data);
        return stringWriter.ToString();
    }
}