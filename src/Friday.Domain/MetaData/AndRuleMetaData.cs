using System.Text.Json;
using Friday.Domain.MetaData.Abstracts;

namespace Friday.Domain.MetaData;

public class AndRuleMetaData : ICombinationRuleMetaData, IDisposable
{
    public string RuleName => nameof(AndRuleMetaData);
    public List<ICombinationRuleMetaData>? Rules { get; set; }
    public JsonDocument? MetaData { get; set; }

    public void Dispose()
    {
        MetaData?.Dispose();
        GC.SuppressFinalize(this);
    }
}