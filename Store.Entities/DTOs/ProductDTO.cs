using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class ProductDTO : IDTO, IMapFrom {
    public int Id { get; set; }
    public string? Key { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? UrlImage  { get; set; }
    public int Stock  { get; set; }
    public bool IsActive { get; set; }

    public List<ProductStoreDTO>? ProductStores { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<Product, ProductDTO>().ReverseMap();
    }
}