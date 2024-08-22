using System.Text.Json;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class ColumnRule : BaseEntity<int>, IDisposable
{
    public JsonDocument? MetaData { get; set; }

    public int ColumnId { get; set; }
    public virtual required Column Column { get; set; }

    public int RuleId { get; set; }
    public virtual required Rule Rule { get; set; }
    
    public void Dispose()
    {
        MetaData?.Dispose();
        GC.SuppressFinalize(this);
    }
}