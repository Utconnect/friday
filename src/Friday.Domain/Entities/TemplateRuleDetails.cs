using System.Text.Json;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class TemplateRuleDetails : BaseEntity<int>, IDisposable
{
    public JsonDocument? MetaData { get; set; }

    public int TemplateId { get; set; }
    public Template Template { get; set; } = null!;

    public int RuleId { get; set; }
    public TemplateRule Rule { get; set; } = null!;

    public void Dispose()
    {
        MetaData?.Dispose();
        GC.SuppressFinalize(this);
    }
}