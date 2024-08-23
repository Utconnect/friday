namespace Friday.Application.Models;

public class DocumentData
{
    public List<DocumentSheetData> Sheets { get; } = [];

    public void Add(DocumentSheetData sheetData)
    {
        Sheets.Add(sheetData);
    }
}