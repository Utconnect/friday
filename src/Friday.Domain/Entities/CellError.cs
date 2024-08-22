using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class CellError : BaseEntity<int>
{
    public int CellId { get; set; }
    public virtual Cell? Cell { get; set; }

    public int ColumnRuleId { get; set; }
    public virtual ColumnRule? ColumnRule { get; set; }
}