using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.MetaData;

namespace Friday.Application.Services.CellValidator;

public partial class CellValidator
{
    private static bool AndRule(Cell cell, JsonDocument? metaData)
    {
        AndRuleMetaData? parsedMetaData = metaData?.Deserialize<AndRuleMetaData>();

        if (parsedMetaData?.Rules == null || parsedMetaData.Rules.Count == 0)
        {
            return true;
        }

        return parsedMetaData.Rules.Any(combinationRuleMetaData => IsValid(cell, combinationRuleMetaData.MetaData));
    }

    private static bool AndRule(Cell cell, JsonElement metaData)
    {
        AndRuleMetaData? parsedMetaData = metaData.Deserialize<AndRuleMetaData>();

        if (parsedMetaData?.Rules == null || parsedMetaData.Rules.Count == 0)
        {
            return true;
        }

        return parsedMetaData.Rules.Any(combinationRuleMetaData => IsValid(cell, combinationRuleMetaData.MetaData));
    }
}