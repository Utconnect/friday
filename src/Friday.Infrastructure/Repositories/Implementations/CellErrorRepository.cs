using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class CellErrorRepository(FridayDbContext dbContext) : ICellErrorRepository
{
    public IEnumerable<CellError> FindByDocumentRecordId(Guid documentRecordId)
    {
        return dbContext.CellErrors.Where(c => c.Cell.Sheet.DocumentRecordId == documentRecordId);
    }

    public async Task AddRangeAsync(IEnumerable<CellError> cellErrors, CancellationToken cancellationToken)
    {
        await dbContext.CellErrors.AddRangeAsync(cellErrors, cancellationToken);
    }
}