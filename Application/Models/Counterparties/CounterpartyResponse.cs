using Application.Models.Contacts;

namespace Application.Models.Counterparties;

public record CounterpartyResponse(
    int Id,
    string Name,
    IReadOnlyCollection<ContactResponse> Contacts);