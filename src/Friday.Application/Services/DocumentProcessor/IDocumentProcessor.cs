using Friday.Application.Models;
using Microsoft.AspNetCore.Http;

namespace Friday.Application.Services.DocumentProcessor;

public interface IDocumentProcessor
{
    DocumentData Process(IFormFile file);
}