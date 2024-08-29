using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.Enums;
using Friday.Domain.MetaData;

namespace Friday.Application.Services.CellValidator;

public partial class CellValidator
{
    private static bool DataTypeRule(Cell cell, JsonDocument? metaData)
    {
        DataTypeRuleMetaData? parsedMetaData = metaData?.Deserialize<DataTypeRuleMetaData>();
        if (parsedMetaData == null)
        {
            return true;
        }

        return parsedMetaData.Type switch
        {
            RuleDataType.Int => int.TryParse(cell.Value, out int _),
            RuleDataType.Double => double.TryParse(cell.Value, out double _),
            _ => false
        };
    }

    private static bool DataTypeRule(Cell cell, JsonElement metaData)
    {
        DataTypeRuleMetaData? parsedMetaData = metaData.Deserialize<DataTypeRuleMetaData>();
        if (parsedMetaData == null)
        {
            return true;
        }

        return parsedMetaData.Type switch
        {
            RuleDataType.Int => int.TryParse(cell.Value, out int _),
            RuleDataType.Double => double.TryParse(cell.Value, out double _),
            _ => false
        };
    }
}