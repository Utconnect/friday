using MediatR;
using Microsoft.AspNetCore.Http;
using Utconnect.Common.Models;

namespace Friday.Application.UseCases.Documents.Commands;

public record SaveDocumentDataCommand(IFormFile File, Guid DocumentId, string TemplateCode) : IRequest<Result>;