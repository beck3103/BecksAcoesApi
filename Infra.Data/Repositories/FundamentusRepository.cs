using Domain.Interfaces.Repositories;
using Infra.Interfaces;

namespace Infra.Data.Repositories;

public sealed class FundamentusRepository(IFundamentusHttpClient fundamentusHttpClient) : IFundamentusRepository
{
    async Task<string> IFundamentusRepository.GetFundamentusData(string ticket) =>
        await fundamentusHttpClient.GetFundamentusDataAsync(ticket);
}