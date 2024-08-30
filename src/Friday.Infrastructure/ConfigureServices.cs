using Friday.Infrastructure.Repositories.Abstracts;
using Friday.Infrastructure.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Friday.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<ICellRepository, CellRepository>();
        services.AddTransient<IColumnRepository, ColumnRepository>();
        services.AddTransient<IDocumentRecordRepository, DocumentRecordRepository>();
        services.AddTransient<ISheetRepository, SheetRepository>();
        services.AddTransient<ITemplateRepository, TemplateRepository>();
    }
}