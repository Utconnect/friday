using Friday.Domain.Entities;
using Utconnect.Common.Models.Errors;

namespace Friday.Domain.Errors.Templates;

public class TemplateNotFoundError(string value, string key = "ID") : NotFoundError<Template>(value, key);