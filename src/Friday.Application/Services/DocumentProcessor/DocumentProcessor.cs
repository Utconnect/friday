using ClosedXML.Excel;
using Friday.Application.Models;
using Microsoft.AspNetCore.Http;

namespace Friday.Application.Services.DocumentProcessor;

public class DocumentProcessor : IDocumentProcessor
{
    public DocumentData Process(IFormFile file)
    {
        DocumentData documentData = new();

        using XLWorkbook workbook = new(file.OpenReadStream());
        IXLWorksheets? ws = workbook.Worksheets;

        foreach (IXLWorksheet worksheet in ws)
        {
            DocumentSheetData sheetData = Process(worksheet);
            documentData.Add(sheetData);
        }

        return documentData;
    }

    private static DocumentSheetData Process(IXLWorksheet worksheet)
    {
        DocumentSheetData sheetData = new();

        foreach (IXLRow row in worksheet.Rows())
        {
            foreach (IXLCell cell in row.Cells())
            {
                if (cell.IsEmpty())
                {
                    continue;
                }

                string cellValue = cell.GetText();
                DocumentCellData cellData = new(row.RowNumber(), cell.WorksheetColumn().ColumnNumber(), cellValue);
                sheetData.Add(cellData);
            }
        }

        return sheetData;
    }
}