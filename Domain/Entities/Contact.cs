using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Domain.Common;
using Domain.Common.Primitives;

namespace Domain.Entities;

public class Contact : BaseAuditableEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Patronymic { get; private set; }
    public string Email { get; private set; }
    public int CounterpartyId { get; private set; }
    public Counterparty Counterparty { get; set; } = null!;
}