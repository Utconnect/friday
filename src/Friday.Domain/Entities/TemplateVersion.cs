using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class TemplateVersion : BaseAuditableEntity<int>
{
    public int Index { get; set; }

    public int TemplateId { get; set; }
    public virtual required Template Template { get; set; }

    public virtual IEnumerable<Column> Columns { get; set; } = [];
}