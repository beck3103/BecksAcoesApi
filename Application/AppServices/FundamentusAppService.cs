using Application.Dtos.Output;
using Application.Interfaces;
using Application.Mappers;
using HtmlAgilityPack;
using Infra.Http.Interfaces;

namespace Application.AppServices;

public sealed class FundamentusAppService(IFundamentusHttpClient fundamentusHttpClient) : IFundamentusAppService
{
    // Example method to get data from Fundamentus
    public async Task<FundamentusRowResultDto?> GetFundamentusDataAsync(string ticket)
    {
        //I'm getting the HTML because the API doesn't allow me to get the data directly in JSON format.
        var resultHTML = await fundamentusHttpClient.GetFundamentusDataAsync(ticket);

        HtmlDocument page = new();
        page.LoadHtml(resultHTML);

        //Here i'll manipulate the html response
        var table = GetFundamentusTableAsync(page, ticket);

        if (table.Count < 0)
            return null;

        var result = table.MapToFundamentusRowResultDto();

        return result;
    }

    public static Dictionary<string, string> GetFundamentusTableAsync(HtmlDocument page, string ticket)
    {
        if (page == null)
            throw new ArgumentNullException(nameof(page), "HTML document cannot be null.");

        // Find the table by id
        var tableNode = page.DocumentNode.SelectSingleNode("//table[@id='resultado']");
        if (tableNode == null)
            return [];

        // Get headers
        var headerNodes = tableNode.SelectNodes(".//thead/tr/th");
        var headers = headerNodes?.Select(h => h.InnerText.Trim()).ToList() ?? [];

        // Get rows
        var rowNodes = tableNode.SelectNodes(".//tbody/tr");
        var tableData = new List<Dictionary<string, string>>();

        if (rowNodes != null)
        {
            foreach (var row in rowNodes)
            {
                var cellNodes = row.SelectNodes("td");
                if (cellNodes == null || cellNodes.Count == 0) continue;

                // Check if the first cell contains an <a> tag with the ticket text
                var aTag = cellNodes[0].SelectSingleNode(".//a");
                if (aTag != null && aTag.InnerText.Trim().Equals(ticket, StringComparison.OrdinalIgnoreCase))
                {
                    var rowDict = new Dictionary<string, string>();
                    for (int i = 0; i < cellNodes.Count && i < headers.Count; i++)
                    {
                        rowDict[headers[i]] = cellNodes[i].InnerText.Trim();
                    }
                    return rowDict;
                }
            }
        }

        return [];
    }
}