namespace Taxually.TechnicalTest.Interfaces;

public interface ITaxuallyHttpClient
{
    Task PostAsync<TRequest>(string url, TRequest request);
}