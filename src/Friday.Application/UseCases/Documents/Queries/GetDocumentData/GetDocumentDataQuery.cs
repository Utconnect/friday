using MediatR;
using Utconnect.Common.Models;

namespace Friday.Application.UseCases.Documents.Queries.GetDocumentData;

public record GetDocumentDataQuery(Guid DocumentRecordId) : IRequest<Result<GetDocumentDataQueryResponse>>;