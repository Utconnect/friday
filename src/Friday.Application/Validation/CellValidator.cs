using Friday.Domain.Entities;
using Friday.Domain.Enums;

namespace Friday.Application.Validation;

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
            if (!IsValid(cell, columnRule.Rule))
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

    private bool IsValid(Cell cell, Rule rule)
    {
        return rule.Code switch
        {
            RuleType.NotEmpty => NotEmptyRule(cell),
            RuleType.Type => TypeRule(cell),
            _ => true
        };
    }

    private static bool NotEmptyRule(Cell cell)
    {
        return !string.IsNullOrEmpty(cell.Value);
    }

    private static bool TypeRule(Cell cell)
    {
        return !string.IsNullOrEmpty(cell.Value);
    }
}