using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;

namespace Friday.Infrastructure.Repositories.Implementations;

internal class ColumnRepository(FridayDbContext dbContext) : IColumnRepository
{
    public IEnumerable<Column> FindByTemplateId(int templateId)
    {
        return dbContext.Columns.Where(c => c.TemplateId == templateId);
    }
}