using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.MetaData;

namespace Friday.Application.Services.CellValidator;

public partial class CellValidator
{
    private static bool OrRule(Cell cell, JsonDocument? metaData)
    {
        OrRuleMetaData? parsedMetaData = metaData?.Deserialize<OrRuleMetaData>();

        if (parsedMetaData?.Rules == null || parsedMetaData.Rules.Count == 0)
        {
            return true;
        }

        return parsedMetaData.Rules.All(combinationRuleMetaData => IsValid(cell, combinationRuleMetaData.MetaData));
    }

    private static bool OrRule(Cell cell, JsonElement metaData)
    {
        OrRuleMetaData? parsedMetaData = metaData.Deserialize<OrRuleMetaData>();

        if (parsedMetaData?.Rules == null || parsedMetaData.Rules.Count == 0)
        {
            return true;
        }

        return parsedMetaData.Rules.All(combinationRuleMetaData => IsValid(cell, combinationRuleMetaData.MetaData));
    }
}