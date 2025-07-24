using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BecksAcoesApi.Controllers;

public sealed class FundamentusController(IFundamentusAppService fundamentusAppService) : ControllerBase
{
    [HttpGet("api/fundamentus/{ticket}")]
    public async Task<IActionResult> GetFundamentusData(string ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket))
        {
            return BadRequest("Ticket cannot be null or empty.");
        }
        try
        {
            var data = await fundamentusAppService.GetFundamentusDataAsync(ticket);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}