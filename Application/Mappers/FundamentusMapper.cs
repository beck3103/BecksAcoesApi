using Application.Dtos.Output;

namespace Application.Mappers;

internal static class FundamentusMapper
{
    internal static FundamentusRowResultDto MapToFundamentusRowResultDto(this Dictionary<string, string> data)
    {
        if (data == null || data.Count == 0) return null;

        return new FundamentusRowResultDto
        {
            Papel = data.GetValueOrDefault("Papel"),
            Cotação = data.GetValueOrDefault("Cotação"),
            PL = data.GetValueOrDefault("P/L"),
            PVP = data.GetValueOrDefault("P/VP"),
            PSR = data.GetValueOrDefault("PSR"),
            DivYield = data.GetValueOrDefault("Div.Yield"),
            PAtivo = data.GetValueOrDefault("P/Ativo"),
            PCapGiro = data.GetValueOrDefault("P/Cap.Giro"),
            PEBIT = data.GetValueOrDefault("P/EBIT"),
            PAtivCircLiq = data.GetValueOrDefault("P/Ativ Circ.Liq"),
            EVEBIT = data.GetValueOrDefault("EV/EBIT"),
            EVEBITDA = data.GetValueOrDefault("EV/EBITDA"),
            MrgEbit = data.GetValueOrDefault("Mrg Ebit"),
            MrgLiq = data.GetValueOrDefault("Mrg. Líq."),
            LiqCorr = data.GetValueOrDefault("Liq. Corr."),
            ROIC = data.GetValueOrDefault("ROIC"),
            ROE = data.GetValueOrDefault("ROE"),
            Liq2meses = data.GetValueOrDefault("Liq.2meses"),
            PatrimLiq = data.GetValueOrDefault("Patrim. Líq"),
            DivBrutPatrim = data.GetValueOrDefault("Dív.Brut/ Patrim."),
            CrescRec5a = data.GetValueOrDefault("Cresc. Rec.5a")
        };
    }
}