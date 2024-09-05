using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface ICellErrorRepository
{
    public IEnumerable<CellError> FindByDocumentRecordId(Guid documentRecordId);

    Task AddRangeAsync(IEnumerable<CellError> cellErrors, CancellationToken cancellationToken);
}