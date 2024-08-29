using Friday.Domain.Enums;
using Friday.Domain.MetaData.Abstracts;

namespace Friday.Domain.MetaData;

public class NotEmptyRuleMetaData : IRuleMetaData
{
    public string RuleName => nameof(NotEmptyRuleMetaData);
}