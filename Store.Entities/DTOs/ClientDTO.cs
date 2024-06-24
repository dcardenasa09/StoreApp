using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class ClientDTO : IDTO, IMapFrom {

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Phone  { get; set; }
    public string? Email  { get; set; }
    public string? Address  { get; set; }
    public bool IsActive { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Client, ClientDTO>().ReverseMap();
    }
}