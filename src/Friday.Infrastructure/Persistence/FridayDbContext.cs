using System.Reflection;
using Friday.Domain.Entities;
using Friday.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Utconnect.Common.Infrastructure.Db.Interceptors;
using Utconnect.Common.Infrastructure.Db.Persistence;

namespace Friday.Infrastructure.Persistence;

internal class FridayDbContext(
    DbContextOptions<FridayDbContext> options,
    AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Cell> Cells => Set<Cell>();
    public DbSet<CellError> CellErrors => Set<CellError>();
    public DbSet<Column> Columns => Set<Column>();
    public DbSet<ColumnRule> ColumnRules => Set<ColumnRule>();
    public DbSet<ColumnRuleDetails> ColumnRuleDetails => Set<ColumnRuleDetails>();
    public DbSet<DocumentRecord> DocumentRecords => Set<DocumentRecord>();
    public DbSet<Sheet> Sheets => Set<Sheet>();
    public DbSet<Template> Templates => Set<Template>();
    public DbSet<TemplateRule> TemplateRules => Set<TemplateRule>();
    public DbSet<TemplateRuleDetails> TemplateRuleDetails => Set<TemplateRuleDetails>();

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
        PrePopulateColumnRule(builder);
        PrePopulateTemplateRule(builder);
    }

    private static void PrePopulateColumnRule(ModelBuilder builder)
    {
        builder.Entity<ColumnRule>().HasData(
        [
            new ColumnRule
            {
                Id = 1,
                Name = "And",
                Code = ColumnRuleType.And,
                Description = "Combine multiple conditions"
            },
            new ColumnRule
            {
                Id = 2,
                Name = "Or",
                Code = ColumnRuleType.Or,
                Description = "At least on of multiple conditions"
            },
            new ColumnRule
            {
                Id = 3,
                Name = "NotEmpty",
                Code = ColumnRuleType.NotEmpty,
                Description = "The field should not be empty"
            },
            new ColumnRule
            {
                Id = 4,
                Name = "Type",
                Code = ColumnRuleType.DataType,
                Description = "The field should not be specific type"
            }
        ]);
    }

    private static void PrePopulateTemplateRule(ModelBuilder builder)
    {
        builder.Entity<TemplateRule>().HasData(
        [
            new TemplateRule
            {
                Id = 1,
                Name = "ColumnsNumber",
                Code = TemplateRuleType.ColumnsNumber,
                Description = "Number of columns"
            },
            new TemplateRule
            {
                Id = 2,
                Name = "StartLineNumber",
                Code = TemplateRuleType.StartLineNumber,
                Description = "Number of starting line"
            }
        ]);
    }
}