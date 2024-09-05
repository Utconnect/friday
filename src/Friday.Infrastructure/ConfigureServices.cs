using Friday.Infrastructure.Persistence;
using Friday.Infrastructure.Repositories.Abstracts;
using Friday.Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Infrastructure.Db;

namespace Friday.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddUnitOfWork<FridayDbContext>();
        services.AddTransient<ICellRepository, CellRepository>();
        services.AddTransient<ICellErrorRepository, CellErrorRepository>();
        services.AddTransient<IColumnRepository, ColumnRepository>();
        services.AddTransient<IDocumentRecordRepository, DocumentRecordRepository>();
        services.AddTransient<ISheetRepository, SheetRepository>();
        services.AddTransient<ITemplateRepository, TemplateRepository>();
    }
}