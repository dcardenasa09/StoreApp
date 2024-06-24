using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class BranchStoreDTO : IDTO, IMapFrom {

    public int Id { get; set; }
    public string? Branch { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<BranchStore, BranchStoreDTO>().ReverseMap();
    }
}