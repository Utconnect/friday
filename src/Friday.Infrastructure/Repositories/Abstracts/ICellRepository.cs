using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface ICellRepository
{
    public IEnumerable<Cell> FindByDocumentRecordId(Guid documentRecordId);

    Task AddRangeAsync(IEnumerable<Cell> cells, CancellationToken cancellationToken);
}