using Application.Contracts;
using Application.Models.Contacts;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ContactService(IContact contactRepository, IMapper mapper)
    : IContactService
{
    public async Task<IReadOnlyCollection<ContactResponse>> AllAsync()
    {
        var response = await contactRepository.AllAsync();
        return mapper.Map<IReadOnlyCollection<ContactResponse>>(response);
    }

    public async Task<ContactResponse?> FindAsync(int id)
    {
        var contact = await contactRepository.FindAsync(id);

        return mapper.Map<ContactResponse>(contact);
    }

    public async Task<int> Create(ContactRequest contact)
    {
        return await contactRepository.AddAsync(mapper.Map<Contact>(contact));
    }

    public async Task<int> UpdateAsync(int id, ContactRequest contact)
    {
        return await contactRepository.UpdateAsync(id, mapper.Map<Contact>(contact));
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await contactRepository.DeleteAsync(id);
    }
}