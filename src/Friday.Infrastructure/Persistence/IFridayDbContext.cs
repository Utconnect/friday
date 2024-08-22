using Friday.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Friday.Infrastructure.Persistence;

public interface IFridayDbContext
{
    DbSet<Cell> Cells { get; }
    DbSet<CellError> CellErrors { get; }
    DbSet<Column> Columns { get; }
    DbSet<ColumnRule> ColumnRules { get; }
    DbSet<Rule> Rules { get; }
    DbSet<Template> Templates { get; }
    DbSet<TemplateVersion> Versions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}