using System.ComponentModel.DataAnnotations;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Template : BaseAuditableEntity<int>
{
    [MaxLength(100)]
    public required string Code { get; set; }

    [MaxLength(100)]
    public required string Name { get; set; }

    public IEnumerable<DocumentRecord> DocumentRecords { get; set; } = [];
    public IEnumerable<TemplateRuleDetails> Rules { get; set; } = [];
}