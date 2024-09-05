using Friday.Application.UseCases.Documents.Commands.SaveDocumentData;
using Friday.Application.UseCases.Documents.Commands.ValidateDocumentData;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utconnect.Common.Models;

namespace Friday.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<Result<Guid>> SaveData([FromBody] SaveDocumentDataCommand command)
    {
        return await sender.Send(command);
    }

    [HttpPost("{id:guid}")]
    public async Task<Result> Validate(Guid id)
    {
        ValidateDocumentDataCommand command = new(id);
        return await sender.Send(command);
    }

    [HttpGet("{id:guid}/error")]
    public async Task<Result> GetErrors(Guid id)
    {
        ValidateDocumentDataCommand command = new(id);
        return await sender.Send(command);
    }
}