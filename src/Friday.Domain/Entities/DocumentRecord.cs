using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class DocumentRecord : BaseEntity<Guid>
{
    public Guid DocumentId { get; set; }

    public int TemplateId { get; set; }
    public Template Template { get; set; } = null!;
}