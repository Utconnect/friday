using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface IDocumentRecordRepository
{
    Task AddAsync(DocumentRecord documentRecord, CancellationToken cancellationToken);
}