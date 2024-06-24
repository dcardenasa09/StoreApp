using AutoMapper;
using Store.Entities.Entities;
using Store.Entities.Common.Mapping;
using Store.Entities.Common.Interfaces;

namespace Store.Entities.DTOs;

public class PurchaseDetailDTO : IDTO, IMapFrom {

    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public int ProductStoreId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public bool IsActive { get; set; }

    public ProductStoreResponseDTO? ProductStore { get; set; }

    public void Mapping(Profile profile) {
        profile.CreateMap<PurchaseDetail, PurchaseDetailDTO>().ReverseMap();
    }
}