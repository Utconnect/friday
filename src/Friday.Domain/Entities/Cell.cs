﻿using System.ComponentModel.DataAnnotations;
using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Cell : BaseEntity<int>
{
    public int RowIdx { get; set; }
    public int ColumnIdx { get; set; }

    [MaxLength(1000)]
    public required string Value { get; set; }

    public int? ColumnId { get; set; }
    public Column? Column { get; set; }

    public int SheetId { get; set; }
    public Sheet Sheet { get; set; } = null!;

    public IEnumerable<CellError> Errors { get; set; } = [];
}