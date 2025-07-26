using Application.Dtos.Output;

namespace Application.Interfaces;

public interface IFundamentusAppService
{
    Task<FundamentusRowResultDto?> GetFundamentusDataAsync(string ticket);
}