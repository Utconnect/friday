using Friday.Infrastructure.Repositories.Abstracts;
using MediatR;
using Utconnect.Common.MediatR.Abstractions;
using Utconnect.Common.Models;

namespace Friday.Application.UseCases.Documents.Queries.GetDocumentData;

internal class GetDocumentDataQueryHandler(ICellErrorRepository cellErrorRepository, ISheetRepository sheetRepository)
    : Validatable, IRequestHandler<GetDocumentDataQuery, Result<GetDocumentDataQueryResponse>>
{
    public Task<Result<GetDocumentDataQueryResponse>> Handle(GetDocumentDataQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<GetDocumentDataQueryResponseSheet> cells = sheetRepository
            .FindByDocumentRecordId(request.DocumentRecordId)
            .Select(GetDocumentDataQueryResponseSheet.FromSheet);
        IEnumerable<GetDocumentDataQueryResponseError> errors = cellErrorRepository
            .FindByDocumentRecordId(request.DocumentRecordId)
            .Select(GetDocumentDataQueryResponseError.FromCellError);

        Result<GetDocumentDataQueryResponse> result = Result.Succeed(new GetDocumentDataQueryResponse(cells, errors));

        return Task.FromResult(result);
    }
}