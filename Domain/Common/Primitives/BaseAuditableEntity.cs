namespace Domain.Common.Primitives;

public class BaseAuditableEntity: BaseEntity
{
    public DateTimeOffset? CreationDate { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
}