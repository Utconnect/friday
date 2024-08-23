namespace Friday.Application.Models;

public class DocumentSheetData
{
    public List<DocumentCellData> Cells { get; } = [];

    public void Add(DocumentCellData cellData)
    {
        Cells.Add(cellData);
    }
}