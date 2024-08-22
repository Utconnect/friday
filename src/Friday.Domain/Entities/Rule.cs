using System.ComponentModel.DataAnnotations;
using Friday.Domain.Enums;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Rule : BaseEntity<int>
{
    public RuleType Code { get; set; }

    [MaxLength(10)]
    public required string Name { get; set; }

    public virtual IEnumerable<ColumnRule> ColumnRules { get; set; } = [];

    [MaxLength(100)]
    public string? Description { get; set; }
}