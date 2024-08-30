using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class CellError : BaseEntity<int>
{
    public int CellId { get; set; }
    public Cell Cell { get; set; } = null!;

    public int ColumnRuleId { get; set; }
    public ColumnRuleDetails ColumnRule { get; set; } = null!;
}