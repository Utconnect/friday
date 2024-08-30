using MediatR;
using Utconnect.Common.Models;

namespace Friday.Application.UseCases.Documents.Commands.ValidateDocumentData;

public record ValidateDocumentDataCommand(Guid DocumentRecordId) : IRequest<Result>;