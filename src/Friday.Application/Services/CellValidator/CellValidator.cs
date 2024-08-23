using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.Enums;
using Friday.Domain.MetaData;

namespace Friday.Application.Services.CellValidator;

public class CellValidator : ICellValidator
{
    public List<CellError>? Validate(Cell cell)
    {
        if (!cell.Column.ColumnRules.Any())
        {
            return null;
        }

        List<CellError> errors = [];
        foreach (ColumnRule columnRule in cell.Column.ColumnRules)
        {
            if (!IsValid(cell, columnRule))
            {
                errors.Add(new CellError
                {
                    CellId = cell.Id,
                    ColumnRuleId = columnRule.Id
                });
            }
        }

        return errors;
    }

    private static bool IsValid(Cell cell, ColumnRule columnRule)
    {
        return columnRule.Rule.Code switch
        {
            RuleType.NotEmpty => NotEmptyRule(cell),
            RuleType.DataType => DataTypeRule(cell, columnRule.MetaData),
            _ => true
        };
    }

    private static bool NotEmptyRule(Cell cell)
    {
        return !string.IsNullOrEmpty(cell.Value);
    }

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
}