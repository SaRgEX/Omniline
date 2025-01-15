namespace Application.Models.Contacts;

public record ContactResponse(
    int Id,
    string FirstName,
    string LastName,
    string Patronymic,
    string Email);