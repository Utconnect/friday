using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface ISheetRepository
{
    IEnumerable<Sheet> FindByDocumentRecordId(Guid documentRecordId);

    Task AddAsync(Sheet sheet, CancellationToken cancellationToken);
}