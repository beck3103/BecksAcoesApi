namespace Infra.Http.Interfaces;

public interface IFundamentusHttpClient
{
    Task<string> GetFundamentusDataAsync(string ticket);
}