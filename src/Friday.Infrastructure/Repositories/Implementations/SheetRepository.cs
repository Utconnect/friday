using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class SheetRepository(FridayDbContext dbContext) : ISheetRepository
{
    public IEnumerable<Sheet> FindByDocumentRecordId(Guid documentRecordId)
    {
        return dbContext.Sheets
            .Where(s => s.DocumentRecordId == documentRecordId)
            .Include(s => s.Cells)
            .ThenInclude(c => c.Errors)
            .ThenInclude(e => e.ColumnRule)
            .ThenInclude(cr => cr.Rule);
    }

    public async Task AddAsync(Sheet sheet, CancellationToken cancellationToken)
    {
        await dbContext.Sheets.AddAsync(sheet, cancellationToken);
    }
}