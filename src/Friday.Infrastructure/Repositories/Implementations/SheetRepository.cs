using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class SheetRepository(FridayDbContext dbContext) : ISheetRepository
{
    public async Task AddAsync(Sheet sheet, CancellationToken cancellationToken)
    {
        await dbContext.Sheets.AddAsync(sheet, cancellationToken);
    }
}