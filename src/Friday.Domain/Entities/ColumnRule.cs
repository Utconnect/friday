using System.ComponentModel.DataAnnotations;
using Friday.Domain.Enums;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class ColumnRule : BaseEntity<int>
{
    public ColumnRuleType Code { get; set; }

    [MaxLength(10)]
    public required string Name { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }

    public IEnumerable<ColumnRuleDetails> ColumnRules { get; set; } = [];
}