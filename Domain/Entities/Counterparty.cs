using Domain.Common;
using Domain.Common.Primitives;

namespace Domain.Entities;

public class Counterparty : BaseAuditableEntity
{
    public string Name { get; private set; }
    public ICollection<Contact> Contacts { get; set; } = [];
}