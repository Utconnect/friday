using System.Reflection;
using Friday.Application.Services.CellValidator;
using Friday.Application.Services.DocumentProcessor;
using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.MediatR;

namespace Friday.Application;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddCommonMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<ICellValidator, CellValidator>();
        services.AddTransient<IDocumentProcessor, DocumentProcessor>();
    }
}