using Application.Models.Counterparties;
using Domain.Entities;

namespace Application.Models.Contacts;

public record ContactRequest(
    string FirstName,
    string LastName,
    string Patronymic,
    string Email,
    int CounterpartyId);