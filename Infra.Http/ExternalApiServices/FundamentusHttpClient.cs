using Infra.Http.Interfaces;

namespace Infra.Http.ExternalApiServices;

public class FundamentusHttpClient(HttpClient httpClient) : IFundamentusHttpClient
{
    public async Task<string> GetFundamentusDataAsync(string ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket))
            throw new ArgumentException("URL cannot be null or empty.", nameof(ticket));

        var response = await httpClient.GetAsync(ticket);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}