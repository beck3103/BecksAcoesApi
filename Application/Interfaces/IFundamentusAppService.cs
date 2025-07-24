namespace Application.Interfaces;

public interface IFundamentusAppService
{
    Task<string> GetFundamentusDataAsync(string ticket);
}