using System.Text.Json;

namespace Friday.Domain.MetaData.Abstracts;

public interface ICombinationRuleMetaData : IRuleMetaData
{
    public List<ICombinationRuleMetaData>? Rules { get; set; }
    public JsonDocument? MetaData { get; set; }
}