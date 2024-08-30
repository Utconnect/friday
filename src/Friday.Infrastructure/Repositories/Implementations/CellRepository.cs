using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class CellRepository(FridayDbContext dbContext) : ICellRepository
{
    public IEnumerable<Cell> FindByDocumentRecordId(Guid documentRecordId)
    {
        return dbContext.Cells.Where(c => c.Sheet.DocumentRecordId == documentRecordId);
    }

    public async Task AddRangeAsync(IEnumerable<Cell> cells, CancellationToken cancellationToken)
    {
        await dbContext.Cells.AddRangeAsync(cells, cancellationToken);
    }
}