using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BecksAcoesApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public sealed class FundamentusController(IFundamentusAppService fundamentusAppService) : ControllerBase
{
    [HttpGet("fundamentus/{ticket}")]
    public async Task<IActionResult> GetFundamentusData(string ticket)
    {
        if (string.IsNullOrWhiteSpace(ticket))
            return BadRequest("Ticket cannot be null or empty.");

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