using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class ProductStoreResponseDTO : IDTO, IMapFrom {

    public int Id { get; set; }
    public int ProductId { get; set; }
    public int BranchStoreId { get; set; }
    public DateTime Date  { get; set; }
    public bool IsActive { get; set; }

    public ProductDTO? Product { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<ProductStore, ProductStoreResponseDTO>().ReverseMap();
    }
}