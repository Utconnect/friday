using Friday.Domain.Entities;

namespace Friday.Infrastructure.Repositories.Abstracts;

public interface IColumnRepository
{
    IEnumerable<Column> FindByTemplateId(int templateId);
}