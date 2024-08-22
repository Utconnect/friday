using Friday.Domain.Entities;

namespace Friday.Application.Validation;

public interface ICellValidator
{
    List<CellError>? Validate(Cell cell);
}