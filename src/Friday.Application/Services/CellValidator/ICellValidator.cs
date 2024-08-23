using Friday.Domain.Entities;

namespace Friday.Application.Services.CellValidator;

public interface ICellValidator
{
    List<CellError>? Validate(Cell cell);
}