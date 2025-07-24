using Infra.Http.Interfaces;

namespace Infra.Http.ExternalApiServices;

public class FundamentusHttpClient(HttpClient httpClient) : IFundamentusHttpClient
{
    public async Task<string> GetFundamentusDataAsync(string ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket))
            throw new ArgumentException("URL cannot be null or empty.", nameof(ticket));

        string path = string.Concat("/resultado.php?papel=", ticket);

        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
        httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml");

        var response = await httpClient.GetAsync(path);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}