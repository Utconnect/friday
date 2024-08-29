using Friday.Domain.Entities;

namespace Friday.Application.Services.CellValidator;

public partial class CellValidator
{
    private static bool NotEmptyRule(Cell cell)
    {
        return !string.IsNullOrEmpty(cell.Value);
    }
}