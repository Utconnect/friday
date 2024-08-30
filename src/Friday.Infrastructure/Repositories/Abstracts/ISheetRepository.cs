using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface ISheetRepository
{
    Task AddAsync(Sheet sheet, CancellationToken cancellationToken);
}