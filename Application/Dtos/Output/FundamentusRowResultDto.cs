using System.Text.Json.Serialization;

namespace Application.Dtos.Output;

public class FundamentusRowResultDto
{
    private string? _cotacao;
    public string? Papel { get; set; } = string.Empty;

    [JsonPropertyName("cotação")]
    public string? Cotação
    {
        set
        {
            _cotacao = value;
        }
    }

    public string? Cotacao => _cotacao?.Replace("R$", "").Trim();

    public string? PL { get; set; } = string.Empty;
    public string? PVP { get; set; } = string.Empty;
    public string? PSR { get; set; } = string.Empty;
    public string? DivYield { get; set; } = string.Empty;
    public string? PAtivo { get; set; } = string.Empty;
    public string? PCapGiro { get; set; } = string.Empty;
    public string? PEBIT { get; set; } = string.Empty;
    public string? PAtivCircLiq { get; set; } = string.Empty;
    public string? EVEBIT { get; set; } = string.Empty;
    public string? EVEBITDA { get; set; } = string.Empty;
    public string? MrgEbit { get; set; } = string.Empty;
    public string? MrgLiq { get; set; } = string.Empty;
    public string? LiqCorr { get; set; } = string.Empty;
    public string? ROIC { get; set; } = string.Empty;
    public string? ROE { get; set; } = string.Empty;
    public string? Liq2meses { get; set; } = string.Empty;
    public string? PatrimLiq { get; set; } = string.Empty;
    public string? DivBrutPatrim { get; set; } = string.Empty;
    public string? CrescRec5a { get; set; } = string.Empty;
}