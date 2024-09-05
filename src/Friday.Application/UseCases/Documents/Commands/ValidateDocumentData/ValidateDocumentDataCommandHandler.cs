using Friday.Application.Services.CellValidator;
using Friday.Domain.Entities;
using Friday.Infrastructure.Repositories.Abstracts;
using MediatR;
using Utconnect.Common.MediatR.Abstractions;
using Utconnect.Common.Models;

namespace Friday.Application.UseCases.Documents.Commands.ValidateDocumentData;

internal class ValidateDocumentDataCommandHandler(
    ICellRepository cellRepository,
    ICellErrorRepository cellErrorRepository,
    ICellValidator cellValidator)
    : Validatable, IRequestHandler<ValidateDocumentDataCommand, Result>
{
    public async Task<Result> Handle(ValidateDocumentDataCommand request, CancellationToken cancellationToken)
    {
        IEnumerable<Cell> cells = cellRepository.FindByDocumentRecordId(request.DocumentRecordId);

        foreach (Cell cell in cells)
        {
            List<CellError>? errors = cellValidator.Validate(cell);
            if (errors is { Count: > 0 })
            {
                await cellErrorRepository.AddRangeAsync(errors, cancellationToken);
            }
        }

        return Result.Succeed();
    }
}