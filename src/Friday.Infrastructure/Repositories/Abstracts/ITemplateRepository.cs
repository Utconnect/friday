using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface ITemplateRepository
{
    Task<Template?> GetByCodeAsync(string code, CancellationToken cancellationToken);
}