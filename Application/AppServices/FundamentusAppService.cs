using Application.Interfaces;
using Infra.Http.Interfaces;

namespace Application.AppServices;

public sealed class FundamentusAppService(IFundamentusHttpClient fundamentusHttpClient) : IFundamentusAppService
{
    // Example method to get data from Fundamentus
    public async Task<string> GetFundamentusDataAsync(string ticket)
    {
        var resultado = await fundamentusHttpClient.GetFundamentusDataAsync(ticket);

        //Here i'll manipulate the html response

        return resultado;
    }
}