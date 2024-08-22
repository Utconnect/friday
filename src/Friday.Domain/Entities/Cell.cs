using System.ComponentModel.DataAnnotations;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Cell : BaseEntity<int>
{
    public int Row { get; set; }

    [MaxLength(1000)]
    public string? Value { get; set; }

    public int ColumnId { get; set; }
    public virtual required Column Column { get; set; }

    public virtual IEnumerable<CellError> Errors { get; set; } = [];
}