using System.Text.Json;
using Friday.Domain.Entities;
using Friday.Domain.Enums;

namespace Friday.Application.UseCases.Documents.Queries.GetDocumentData;

public record GetDocumentDataQueryResponse(
    IEnumerable<GetDocumentDataQueryResponseSheet> Data,
    IEnumerable<GetDocumentDataQueryResponseError> Errors);

public class GetDocumentDataQueryResponseSheet
{
    public Guid Id { get; private set; }
    public int Index { get; private set; }
    public string Name { get; private set; } = default!;
    public IEnumerable<GetDocumentDataQueryResponseCell> Cells { get; private set; } = [];

    public static GetDocumentDataQueryResponseSheet FromSheet(Sheet sheet)
    {
        return new GetDocumentDataQueryResponseSheet
        {
            Id = sheet.Id,
            Index = sheet.Index,
            Name = sheet.Name,
            Cells = sheet.Cells.Select(GetDocumentDataQueryResponseCell.FromCell)
        };
    }
}

public class GetDocumentDataQueryResponseCell
{
    public int Id { get; private set; }
    public int RowIdx { get; private set; }
    public int ColumnIdx { get; private set; }
    public string Value { get; set; } = default!;
    public IEnumerable<GetDocumentDataQueryResponseError> Errors { get; set; } = [];

    public static GetDocumentDataQueryResponseCell FromCell(Cell cell)
    {
        return new GetDocumentDataQueryResponseCell
        {
            Id = cell.Id,
            RowIdx = cell.RowIdx,
            ColumnIdx = cell.ColumnIdx,
            Value = cell.Value,
            Errors = cell.Errors.Select(GetDocumentDataQueryResponseError.FromCellError)
        };
    }
}

public record GetDocumentDataQueryResponseError
{
    public ColumnRuleType Code { get; private set; }
    public string Name { get; private set; } = default!;
    public JsonDocument? MetaData { get; private set; }

    public static GetDocumentDataQueryResponseError FromCellError(CellError cellError)
    {
        return new GetDocumentDataQueryResponseError
        {
            Code = cellError.ColumnRule.Rule.Code,
            Name = cellError.ColumnRule.Rule.Name,
            MetaData = cellError.ColumnRule.MetaData
        };
    }
}