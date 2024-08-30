using Friday.Application.Models;
using Friday.Application.Services.DocumentProcessor;
using Friday.Domain.Entities;
using Friday.Infrastructure.Repositories.Abstracts;
using MediatR;
using Utconnect.Common.MediatR.Abstractions;
using Utconnect.Common.Models;
using Utconnect.Common.Models.Errors;

namespace Friday.Application.UseCases.Documents.Commands.SaveDocumentData;

internal class SaveDocumentDataCommandHandler(
    ICellRepository cellRepository,
    IColumnRepository columnRepository,
    IDocumentRecordRepository documentRecordRepository,
    ISheetRepository sheetRepository,
    ITemplateRepository templateRepository,
    IDocumentProcessor documentProcessor)
    : Validatable, IRequestHandler<SaveDocumentDataCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(SaveDocumentDataCommand request, CancellationToken cancellationToken)
    {
        DocumentData documentData = documentProcessor.Process(request.File);

        Template? template = await templateRepository.GetByCodeAsync(request.TemplateCode, cancellationToken);
        if (template == null)
        {
            return Result<Guid>.Failure(new NotFoundError("Template is not found"));
        }

        Guid documentRecordId = Guid.NewGuid();

        await documentRecordRepository.AddAsync(new DocumentRecord
        {
            Id = documentRecordId,
            DocumentId = request.DocumentId,
            TemplateId = template.Id
        }, cancellationToken);

        List<Column> columns = columnRepository.FindByTemplateId(template.Id).ToList();

        for (int i = 0; i < documentData.Sheets.Count; i++)
        {
            Guid sheetId = Guid.NewGuid();

            Sheet sheetToAdd = new()
            {
                Id = sheetId,
                Index = i,
                DocumentRecordId = documentRecordId
            };
            await sheetRepository.AddAsync(sheetToAdd, cancellationToken);

            IEnumerable<Cell> cellsToAdd = documentData.Sheets[i].Cells.Select(c => new Cell
            {
                RowIdx = c.Row,
                ColumnIdx = c.Column,
                ColumnId = columns[i].Id,
                Value = c.Value
            });

            await cellRepository.AddRangeAsync(cellsToAdd, cancellationToken);
        }

        return Result<Guid>.Succeed(documentRecordId);
    }
}