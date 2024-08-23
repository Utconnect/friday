using Utconnect.Common.Infrastructure.Db.Entities;

namespace Friday.Domain.Entities;

public class Sheet : BaseEntity
{
    public Guid DocumentId { get; set; }

    public int Index { get; set; }
    
    public int TemplateId { get; set; }
    public Template? Template { get; set; }
    
    public IEnumerable<Cell> Cells { get; set; } = [];
}