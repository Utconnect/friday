using Friday.Domain.Enums;
using Friday.Domain.MetaData.Abstracts;

namespace Friday.Domain.MetaData;

public class DataTypeRuleMetaData : IRuleMetaData
{
    public string RuleName => nameof(DataTypeRuleMetaData);
    public RuleDataType Type { get; set; }
}