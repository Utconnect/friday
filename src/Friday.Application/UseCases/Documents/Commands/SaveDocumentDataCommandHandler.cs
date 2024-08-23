using Friday.Application.Models;
using Friday.Application.Services.DocumentProcessor;
using Friday.Domain.Entities;
using Friday.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utconnect.Common.MediatR.Abstractions;
using Utconnect.Common.Models;
using Utconnect.Common.Models.Errors;

namespace Friday.Application.UseCases.Documents.Commands;

internal class SaveDocumentDataCommandHandler(IFridayDbContext dbContext, IDocumentProcessor documentProcessor)
    : Validatable, IRequestHandler<SaveDocumentDataCommand, Result>
{
    public async Task<Result> Handle(SaveDocumentDataCommand request, CancellationToken cancellationToken)
    {
        DocumentData documentData = documentProcessor.Process(request.File);

        Template? template = await dbContext.Templates.FirstOrDefaultAsync(t => t.Code == request.TemplateCode,
            cancellationToken);
        if (template == null)
        {
            return Result.Failure(new NotFoundError("Template is not found"));
        }

        List<Column> columns = await dbContext.Columns
            .Where(c => c.TemplateId == template.Id)
            .ToListAsync(cancellationToken);

        for (int i = 0; i < documentData.Sheets.Count; i++)
        {
            Guid sheetId = Guid.NewGuid();

            await dbContext.Sheets.AddAsync(new Sheet
            {
                Id = sheetId,
                DocumentId = request.DocumentId,
                Index = i,
                TemplateId = template.Id
            }, cancellationToken);

            await dbContext.Cells.AddRangeAsync(documentData.Sheets[i].Cells.Select(c => new Cell
            {
                RowIdx = c.Row,
                ColumnIdx = c.Column,
                ColumnId = columns[i].Id,
                Value = c.Value
            }), cancellationToken);
        }

        return Result.Succeed();
    }
}