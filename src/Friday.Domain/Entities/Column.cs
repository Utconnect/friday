using System.ComponentModel.DataAnnotations;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Column : BaseEntity<int>
{
    public int Index { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public int VersionId { get; set; }
    public virtual required TemplateVersion Version { get; set; }

    public virtual IEnumerable<ColumnRule> ColumnRules { get; set; } = [];
}