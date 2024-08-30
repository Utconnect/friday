using System.Text.Json;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class ColumnRuleDetails : BaseEntity<int>, IDisposable
{
    public JsonDocument? MetaData { get; set; }

    public int ColumnId { get; set; }
    public Column Column { get; set; } = null!;

    public int RuleId { get; set; }
    public ColumnRule Rule { get; set; } = null!;
    
    public void Dispose()
    {
        MetaData?.Dispose();
        GC.SuppressFinalize(this);
    }
}