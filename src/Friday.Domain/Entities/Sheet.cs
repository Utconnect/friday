using System.ComponentModel.DataAnnotations;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Sheet : BaseEntity
{
    public int Index { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = default!;

    public Guid DocumentRecordId { get; set; }
    public DocumentRecord DocumentRecord { get; set; } = null!;

    public IEnumerable<Cell> Cells { get; set; } = [];
}