using System.Reflection;
using Friday.Domain.Entities;
using Friday.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Utconnect.Common.Infrastructure.Db.Interceptors;

namespace Friday.Infrastructure.Persistence;

public class FridayDbContext(
    DbContextOptions<FridayDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
    : DbContext(options), IFridayDbContext
{
    public DbSet<Cell> Cells => Set<Cell>();
    public DbSet<CellError> CellErrors => Set<CellError>();
    public DbSet<Column> Columns => Set<Column>();
    public DbSet<ColumnRule> ColumnRules => Set<ColumnRule>();
    public DbSet<Rule> Rules => Set<Rule>();
    public DbSet<Sheet> Sheets => Set<Sheet>();
    public DbSet<Template> Templates => Set<Template>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        PrePopulate(builder);

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    private static void PrePopulate(ModelBuilder builder)
    {
        builder.Entity<Rule>().HasData(
        [
            new Rule
            {
                Id = 1,
                Name = "NotEmpty",
                Code = RuleType.NotEmpty,
                Description = "The field should not be empty"
            },
            new Rule
            {
                Id = 2,
                Name = "Type",
                Code = RuleType.DataType,
                Description = "The field should not be specific type"
            }
        ]);
    }
}