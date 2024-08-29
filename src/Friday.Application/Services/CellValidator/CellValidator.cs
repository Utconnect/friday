using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.Enums;
using Friday.Domain.MetaData;
using Friday.Domain.MetaData.Abstracts;

namespace Friday.Application.Services.CellValidator;

public partial class CellValidator : ICellValidator
{
    public List<CellError>? Validate(Cell cell)
    {
        if (cell.Column == null || !cell.Column.ColumnRules.Any())
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
            RuleType.And => AndRule(cell, columnRule.MetaData),
            RuleType.Or => OrRule(cell, columnRule.MetaData),
            RuleType.DataType => DataTypeRule(cell, columnRule.MetaData),
            RuleType.NotEmpty => NotEmptyRule(cell),
            _ => true
        };
    }

    private static bool IsValid(Cell cell, JsonDocument? metaData)
    {
        if (metaData == null)
        {
            return true;
        }
        
        string? ruleName = metaData.RootElement.GetProperty(nameof(IRuleMetaData.RuleName)).GetString();
        JsonElement subMetaData = metaData.RootElement.GetProperty("MetaData");

        if (ruleName == null)
        {
            throw new ArgumentOutOfRangeException(ruleName);
        }

        return ruleName switch
        {
            nameof(AndRuleMetaData) => AndRule(cell, subMetaData),
            nameof(OrRuleMetaData) => OrRule(cell, subMetaData),
            nameof(DataTypeRuleMetaData) => DataTypeRule(cell, subMetaData),
            nameof(NotEmptyRuleMetaData) => NotEmptyRule(cell),
            _ => throw new ArgumentOutOfRangeException(ruleName)
        };
    }
}