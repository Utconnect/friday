using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class TemplateRepository(FridayDbContext dbContext) : ITemplateRepository
{
    public async Task<Template?> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return await dbContext.Templates.FirstOrDefaultAsync(t => t.Code == code, cancellationToken);
    }
}