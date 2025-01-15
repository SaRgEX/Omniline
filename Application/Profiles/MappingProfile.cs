using Application.Models.Contacts;
using Application.Models.Counterparties;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Contact, ContactResponse>().ReverseMap();
        CreateMap<Contact, ContactRequest>().ReverseMap();
        CreateMap<Counterparty, CounterpartyResponse>().ReverseMap();
        CreateMap<Counterparty, CounterpartyRequest>().ReverseMap();
    }
}