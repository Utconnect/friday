using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class DocumentRecordRepository(FridayDbContext dbContext) : IDocumentRecordRepository
{
    public async Task AddAsync(DocumentRecord documentRecord, CancellationToken cancellationToken)
    {
        await dbContext.DocumentRecords.AddAsync(documentRecord, cancellationToken);
    }
}