using System.Xml.Serialization;
using Taxually.TechnicalTest.Interfaces;

namespace Taxually.TechnicalTest.Services;

public class XmlBuilder(ILogger<XmlBuilder> logger) : IXmlBuilder
{
	public string GetXmlString<T>(T? data) where T : class
	{
		try
		{
			if (data is null)
			{
				throw new InvalidOperationException("Data is null");
			}
			
			using var stringWriter = new StringWriter();
			var serializer = new XmlSerializer(typeof(T));
			serializer.Serialize(stringWriter, data);
			return stringWriter.ToString();
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to serialize object to XML");
			throw new InvalidOperationException("Failed to serialize object to XML", ex);
		}
	}
}